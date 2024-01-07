namespace HotelBookingWeb.Models
{
    public class CameraFacilitate
    {
        public int CameraId { get; set; }
        public Camera Camera { get; set; }

        public int FacilitateId { get; set; }
        public Facilitate Facilitate { get; set; }
    }
}
