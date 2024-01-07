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
    public class IndexModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public IndexModel(HotelBookingWeb.Data.HotelBookingWebContext context)
        {
            _context = context;
        }

        public IList<Facilitate> Facilitate { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Facilitate != null)
            {
                Facilitate = await _context.Facilitate.ToListAsync();
            }
        }
    }
}
