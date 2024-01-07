using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBookingWeb.Data;
using HotelBookingWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingWeb.Pages.Facilitati
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public EditModel(HotelBookingWeb.Data.HotelBookingWebContext context)
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

            var facilitate =  await _context.Facilitate.FirstOrDefaultAsync(m => m.FacilitateId == id);
            if (facilitate == null)
            {
                return NotFound();
            }
            Facilitate = facilitate;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Facilitate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilitateExists(Facilitate.FacilitateId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FacilitateExists(int id)
        {
          return (_context.Facilitate?.Any(e => e.FacilitateId == id)).GetValueOrDefault();
        }
    }
}
