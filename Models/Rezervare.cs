namespace HotelBookingWeb.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rezervare
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Client")]

    public int ClientId { get; set; }

    [Required]
    [ForeignKey("Camera")]
    public int CameraId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data Start")]
    public DateTime DataStart { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Data Sfârșit")]
    public DateTime DataSfarsit { get; set; }

    [StringLength(500)]
    [Display(Name = "Note Adiționale")]
    public string NoteAditionale { get; set; }

    // Navigational properties
    public Client? Client { get; set; }
    public Camera? Camera { get; set; }

    
}

