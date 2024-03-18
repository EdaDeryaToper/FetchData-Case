using Newtonsoft.Json;


namespace BackendCase.Models.Response
{
    public class DoctorRoot
    {

        [JsonProperty("data")]
        public List<Doctor> DoctorData { get; set; }


    }
}
