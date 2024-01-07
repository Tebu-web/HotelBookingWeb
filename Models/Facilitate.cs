namespace HotelBookingWeb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


    public class Facilitate
    {
    public Facilitate()
    {
        CameraFacilitati = new HashSet<CameraFacilitate>();
    }

    [Key]
    public int FacilitateId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nume { get; set; }

    [StringLength(500)]
    public string Descriere { get; set; }

    // Proprietatea de navigare pentru relația many-to-many cu Camera
    public ICollection<CameraFacilitate> CameraFacilitati { get; set; }
}

