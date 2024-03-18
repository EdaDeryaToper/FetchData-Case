using Newtonsoft.Json;
using System.Diagnostics;



namespace BackendCase.Models.Response
{
    public class BookVisitResponseData
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("BookingID")]
        public int BookingId { get; set; }


    }
}
