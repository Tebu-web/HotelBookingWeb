using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelBookingWeb.Data;
using HotelBookingWeb.Models;

namespace HotelBookingWeb.Pages.Camere
{
    public class DetailsModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public DetailsModel(HotelBookingWeb.Data.HotelBookingWebContext context)
        {
            _context = context;
        }

      public Camera Camera { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Camera == null)
            {
                return NotFound();
            }

            var camera = await _context.Camera.FirstOrDefaultAsync(m => m.CameraId == id);
            if (camera == null)
            {
                return NotFound();
            }
            else 
            {
                Camera = camera;
            }
            return Page();
        }
    }
}
