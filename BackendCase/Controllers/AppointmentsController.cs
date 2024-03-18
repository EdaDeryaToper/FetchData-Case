using BackendCase.ExceptionHandler;
using BackendCase.Models.Request;
using BackendCase.Models.Response;
using BackendCase.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BackendCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IReader _apiReader;

        public AppointmentsController(IReader apiReader)
        {
            _apiReader = apiReader;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var response = await _apiReader.GetData();
            if (string.IsNullOrEmpty(response))
                return BadRequest();

            var root = JsonConvert.DeserializeObject<DoctorRoot>(response);
            if (root?.DoctorData == null || root.DoctorData.Count == 0)
                return NotFound(response);

            var names = new List<string>();
            foreach (var doctor in root.DoctorData)
                names.Add(doctor.Name);

            return Ok(names);
        }

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetDoctorSchedule(int doctorId)
        {
            var response = await _apiReader.GetDataAsync(doctorId);
            if (string.IsNullOrEmpty(response))
                return BadRequest();
            if(response=="Not Found")
                return NotFound(new { message = "NO_SLOT_FOUND" });
            var root = JsonConvert.DeserializeObject<ScheduleRoot>(response);
            if (root?.ScheduleData == null || root.ScheduleData.Count == 0)
                return NotFound(new { message = "NO_SLOT_FOUND" });

            var schedulesList = new List<ScheduleResponse>();
            foreach (var schedule in root.ScheduleData)
            {
                var schedules = new ScheduleResponse
                {
                    DoctorId = schedule.DoctorId,
                    VisitId = schedule.VisitId,
                    StartTime = schedule.StartTime,
                    EndTime = schedule.EndTime,
                    Id = schedule.Id
                };
                schedulesList.Add(schedules);
            }

            return Ok(new { data = schedulesList });
        }

        [HttpPost("bookVisit")]
        public async Task<IActionResult> BookVisit([FromBody] Booking requestData)
        {
            var response = await _apiReader.BookData(requestData);
            if (string.IsNullOrEmpty(response))
                return BadRequest();
            if (response == "Not Found")
                return NotFound(new { status = false });
            var responseData = JsonConvert.DeserializeObject<BookVisitResponseData>(response);
            return responseData.Status ? Ok(responseData) : NotFound(new { status = responseData.Status });
        }

        [HttpPost("{bookId}")]
        public async Task<IActionResult> BookVisit(int bookId)
        {
            var response = await _apiReader.BookVisit(bookId);
            if (string.IsNullOrEmpty(response))
                return BadRequest();
            if (response == "Not Found")
                return NotFound(new { status = false });
            var responseData = JsonConvert.DeserializeObject<BookVisitResponseData>(response);
            return responseData.Status ? Ok(new { status = responseData.Status }) : NotFound(new { status = responseData.Status });
        }
    }
}
