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
    public class IndexModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public IndexModel(HotelBookingWeb.Data.HotelBookingWebContext context)
        {
            _context = context;
        }

        public IList<Camera> Camera { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Camera != null)
            {
                Camera = await _context.Camera.ToListAsync();
                //.Include(b => b.Rezervari)
                //.ToList();
            }
        }
    }
}
