using Newtonsoft.Json;

namespace BackendCase.Models.Response
{
    public class ScheduleRoot
    {
        [JsonProperty("data")]
        public List<Schedule> ScheduleData { get; set; }
    }
}
