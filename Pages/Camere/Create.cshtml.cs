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

namespace HotelBookingWeb.Pages.Camere
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
        public Camera Camera { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Camera == null || Camera == null)
            {
                return Page();
            }

            _context.Camera.Add(Camera);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
