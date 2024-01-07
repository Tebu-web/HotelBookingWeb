using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelBookingWeb.Data;

namespace HotelBookingWeb.Pages.Recenzii
{
    public class CreateModel : PageModel
    {
        private readonly HotelBookingWeb.Data.HotelBookingWebContext _context;

        public CreateModel(HotelBookingWeb.Data.HotelBookingWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Nume");
            return Page();
        }

        [BindProperty]
        public Recenzie Recenzie { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Recenzie == null || Recenzie == null)
            {
                ViewData["ClientId"] = new SelectList(_context.Client, "ClientId" , "Nume");
                return Page();
            }
          if (Recenzie.Client == null)
            {
                Recenzie.Client = await _context.Client.FindAsync(Recenzie.ClientId);
            }
            _context.Recenzie.Add(Recenzie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
