namespace HotelBookingWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Client
{
    [Key]
    public int ClientId { get; set; }


    [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Numele nu poate depăși 30 de caractere.")]
    [Display(Name = "Nume")]
    public string? Nume { get; set; }

    [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Prenumele nu poate depăși 30 de caractere.")]
    [Display(Name = "Prenume")]
    public string? Prenume { get; set; }

    
    [EmailAddress]
    [Display(Name = "Adresa de Email")]
    public string? Email { get; set; }

    
    [Phone]
    [Display(Name = "Număr de Telefon")]
    public string? Telefon { get; set; }
    public Client()
    {
        Rezervari = new HashSet<Rezervare>();
        Recenzii = new HashSet<Recenzie>();

    }

    // Relația cu entitatea Rezervare
    public ICollection<Rezervare> Rezervari { get; set; }
    public ICollection<Recenzie> Recenzii { get; set; }


    // Alte proprietăți și relații pot fi adăugate aici
}

