using BackendCase.Models.Request;
using BackendCase.Models.Response;
using BackendCase.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;



namespace BackendCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private ISitemapReader _sitemapReader;

        public DoctorsController(ISitemapReader sitemapReader)
        {
            _sitemapReader = sitemapReader;
        }

        [HttpGet]
        [Route("sitemap")]
        public IActionResult GetSitemap()
        {
          
             var sitemapUrls = _sitemapReader.ReadSitemap("https://www.doktortakvimi.com/sitemap.xml");
             return Ok(sitemapUrls);
          
        }

        [HttpGet]
        [Route("sitemap/doctorUrl")]
        public IActionResult GetDoctorsUrl()
        {
        
            var sitemapUrls = _sitemapReader.ReadSitemap("https://www.doktortakvimi.com/sitemap.xml");
            _sitemapReader.ReadDoctorUrl(sitemapUrls);
            return Ok();
        
        
        }
    }
}
