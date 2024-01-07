using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace HotelBookingWeb.Models
{
    public class Camera
    {
        
        [Key]
        public int CameraId { get; set; }

        [Required]
        [Display(Name = "Numărul Camerei")]
        public string Numar { get; set; }

        [Required]
        [Display(Name = "Tipul Camerei")]
        public string Tip { get; set; }

        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Prețul trebuie să fie un număr pozitiv.")]
        [Display(Name = "Preț pe Noapte")]
        public decimal Pret { get; set; }

        [Required]
        [Display(Name = "Disponibilitate")]
        public bool Disponibilitate { get; set; }

        [StringLength(500, ErrorMessage = "Descrierea nu poate depăși 500 de caractere.")]
        [Display(Name = "Descriere")]
        public string Descriere { get; set; }
        public Camera()
        {
            Rezervari = new HashSet<Rezervare>();
            CameraFacilitati = new HashSet<CameraFacilitate>();

        }
        public ICollection<Rezervare> Rezervari { get; set; }
        public ICollection<CameraFacilitate> CameraFacilitati { get; set; }

    }

}

