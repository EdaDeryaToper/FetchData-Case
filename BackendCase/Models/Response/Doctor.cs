using Newtonsoft.Json;


namespace BackendCase.Models.Response
{
    public class Doctor
    {

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("hospitalName")]
        public string HospitalName { get; set; }

        [JsonProperty("hospitalId")]
        public int HospitalId { get; set; }

        [JsonProperty("specialtyId")]
        public int SpecialtyId { get; set; }

        [JsonProperty("branchId")]
        public double BranchId { get; set; }

        [JsonProperty("nationality")]
        public string Nationality { get; set; }

        [JsonProperty("doctorId")]
        public string DoctorId { get; set; }

    }


}
