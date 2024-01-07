using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelBookingWeb.Data;
using HotelBookingWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingWeb.Pages.Facilitati
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public DeleteModel(HotelBookingWeb.Data.HotelBookingWebContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Facilitate == null)
            {
                return NotFound();
            }
            var facilitate = await _context.Facilitate.FindAsync(id);

            if (facilitate != null)
            {
                Facilitate = facilitate;
                _context.Facilitate.Remove(Facilitate);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
