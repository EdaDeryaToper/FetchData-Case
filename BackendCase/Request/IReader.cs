using BackendCase.Models.Request;
using RestSharp;

namespace BackendCase.Request
{
    public interface IReader
    {
       
        Task<string> GetData();
        Task<string> GetDataAsync(int doctorId);
        Task<string> BookData(Booking requestData);
        Task<string> BookVisit(int bookId);
    }
}
