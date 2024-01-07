using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelBookingWeb.Data;
using HotelBookingWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace HotelBookingWeb.Pages.Facilitati
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public CreateModel(HotelBookingWeb.Data.HotelBookingWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Facilitate Facilitate { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Facilitate == null || Facilitate == null)
            {
                return Page();
            }

            _context.Facilitate.Add(Facilitate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
