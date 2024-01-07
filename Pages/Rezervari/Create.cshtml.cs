using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelBookingWeb.Data;
using HotelBookingWeb.Models;

namespace HotelBookingWeb.Pages.Rezervari
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
            ViewData["CameraId"] = new SelectList(_context.Camera, "CameraId", "Tip");
            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Rezervare == null || Rezervare == null)
           

            {
                ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "Nume");
                ViewData["CameraId"] = new SelectList(_context.Camera, "CameraId", "Tip");
                return Page();
            }

            
            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
