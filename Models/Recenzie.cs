using HotelBookingWeb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Recenzie
{
    [Key]
    public int RecenzieId { get; set; }

    [Required]
    public string Continut { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    public DateTime DataRecenzie { get; set; } = DateTime.Now;

    // Cheie străină pentru Client
    public int ClientId { get; set; }

    // Proprietate de navigare pentru Client
    [ForeignKey("ClientId")]
    public Client? Client { get; set; }

}

