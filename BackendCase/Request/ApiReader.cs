using BackendCase.ExceptionHandler;
using BackendCase.Models.Request;
using RestSharp;
using System.Net;

namespace BackendCase.Request
{
    public class ApiReader : IReader
    {
        private readonly string baseUrl = "https://fe8f4f5e-f5c2-48b6-974c-097f4cec3de0.mock.pstmn.io";

        private async Task<string> ExecuteRequest(string resource, Method method, Action<RestRequest> customizeRequest = null)
        {
            var options = new RestClientOptions(baseUrl)
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest(resource, method);

            customizeRequest?.Invoke(request); 

            RestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode == HttpStatusCode.TooManyRequests)
            {
                var errorMessage = ExceptionMiddleware.HandleError(HttpStatusCode.TooManyRequests);
                throw new ErrorException(errorMessage);
 
            }
            return response.IsSuccessful ? response.Content : response.StatusDescription;
        }

        public async Task<string> GetData()
        {
            return await ExecuteRequest("/fetchDoctors", Method.Get);
        }

        public async Task<string> GetDataAsync(int doctorId)
        {
            string resource = $"/fetchSchedules?doctorId={doctorId}";
            return await ExecuteRequest(resource, Method.Get);
        }

        public async Task<string> BookData(Booking requestData)
        {
            var resource = "/BookVisit";
            var method = Method.Post;
            Action<RestRequest> customizeRequest = request =>
            {
                request.AddParameter("VisitId", requestData.VisitId.ToString());
                request.AddParameter("startTime", requestData.StartTime.ToString());
                request.AddParameter("endTime", requestData.EndTime.ToString());
                request.AddParameter("date", requestData.Date.ToString());
                request.AddParameter("PatientName", requestData.PatientName);
                request.AddParameter("PatientSurname", requestData.PatientSurname);
                request.AddParameter("hospitalId", requestData.HospitalId.ToString());
                request.AddParameter("doctorId", requestData.DoctorId.ToString());
                request.AddParameter("branchId", requestData.BranchId.ToString());
            };
            return await ExecuteRequest(resource, method, customizeRequest);
        }

        public async Task<string> BookVisit(int bookId)
        {
            var resource = $"/bookVisit?BookingID={bookId}";
            return await ExecuteRequest(resource, Method.Post);
        }
    }
}
