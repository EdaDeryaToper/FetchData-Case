using Newtonsoft.Json;

namespace BackendCase.Models.Response
{
    public class Schedule
    {
        [JsonProperty("doctorId")]
        public int DoctorId { get; set; }

        [JsonProperty("startTime")]
        public DateTime StartTime { get; set; }

        [JsonProperty("endTime")]
        public DateTime EndTime { get; set; }

        [JsonProperty("VisitId")]
        public int VisitId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
