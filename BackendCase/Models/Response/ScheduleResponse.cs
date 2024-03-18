using System.Text.Json.Serialization;

namespace BackendCase.Models.Response
{
    public class ScheduleResponse
    {      
        public int DoctorId { get; set; }
       
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }

        public int VisitId { get; set; }
       
        public string Id { get; set; }
    }
}
