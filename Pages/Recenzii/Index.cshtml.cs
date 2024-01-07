using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelBookingWeb.Data;

namespace HotelBookingWeb.Pages.Recenzii
{
    public class IndexModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public IndexModel(HotelBookingWeb.Data.HotelBookingWebContext context)
        {
            _context = context;
        }

        public IList<Recenzie> Recenzie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Recenzie != null)
            {
                Recenzie = await _context.Recenzie
                .Include(r => r.Client).ToListAsync();
            }
        }
    }
}
