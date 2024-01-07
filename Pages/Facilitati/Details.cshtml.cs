using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelBookingWeb.Data;
using HotelBookingWeb.Models;

namespace HotelBookingWeb.Pages.Facilitati
{
    public class DetailsModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public DetailsModel(HotelBookingWeb.Data.HotelBookingWebContext context)
        {
            _context = context;
        }

      public Facilitate Facilitate { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Facilitate == null)
            {
                return NotFound();
            }

            var facilitate = await _context.Facilitate.FirstOrDefaultAsync(m => m.FacilitateId == id);
            if (facilitate == null)
            {
                return NotFound();
            }
            else 
            {
                Facilitate = facilitate;
            }
            return Page();
        }
    }
}
