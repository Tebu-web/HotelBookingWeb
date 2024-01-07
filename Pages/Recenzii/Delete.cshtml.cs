using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelBookingWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingWeb.Pages.Recenzii
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
      public Recenzie Recenzie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Recenzie == null)
            {
                return NotFound();
            }

            var recenzie = await _context.Recenzie.FirstOrDefaultAsync(m => m.RecenzieId == id);

            if (recenzie == null)
            {
                return NotFound();
            }
            else 
            {
                Recenzie = recenzie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Recenzie == null)
            {
                return NotFound();
            }
            var recenzie = await _context.Recenzie.FindAsync(id);

            if (recenzie != null)
            {
                Recenzie = recenzie;
                _context.Recenzie.Remove(Recenzie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
