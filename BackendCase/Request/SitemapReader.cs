using BackendCase.Models.Response;
using Microsoft.VisualBasic;
using System.IO;
using System.Xml.Serialization;

namespace BackendCase.Request
{
    public class SitemapReader:ISitemapReader
    {
        private List<string> sitemapUrl = new List<string>();
        private readonly HttpClient _httpClient;

        public SitemapReader()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Cookie", "GUEST_SESSION=Iv6elCtICZI-9S_RGfrV4j6Ogb93ec7O73o7Xqm4QyA");
        }

        public string[] ReadSitemap(string path)
        {
            try
            {
                var response = _httpClient.GetAsync(path).Result;
                response.EnsureSuccessStatusCode();
                string contents = response.Content.ReadAsStringAsync().Result;

                var serializer = new XmlSerializer(typeof(Sitemapindex));
                using (StringReader reader = new StringReader(contents))
                {
                    var test = (Sitemapindex)serializer.Deserialize(reader);
                    var testResult = test.Sitemap.Select(o => o.Loc).ToArray();
                    foreach (var item in testResult)
                    {
                        if (item.Contains("doctor"))
                        {
                            sitemapUrl.Add(item);
                        }
                    }
                    return sitemapUrl.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while reading sitemap: {ex.Message}");
                
            }
        }

        public void ReadDoctorUrl(string[] urls)
        {
            foreach (var item in urls)
            {
                try
                {
                    var response = _httpClient.GetAsync(item).Result;
                    response.EnsureSuccessStatusCode();
                    string contents = response.Content.ReadAsStringAsync().Result;

                    var serializer = new XmlSerializer(typeof(Urlset));
                    using (StringReader reader = new StringReader(contents))
                    {
                        var test = (Urlset)serializer.Deserialize(reader);
                        var testResult = test.Url.Select(o => o.Loc).ToArray();
                        foreach (var part in testResult)
                        {
                            string[] urlParts = part.Split('/');
                            WriteToCsv(urlParts);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error while reading doctor URLs: {ex.Message}");
                    
                }
            }
        }

        public void WriteToCsv(string[] parts)
        {
            string csvFilePath = "C:\\Users\\eda_t\\Github\\BackendCase\\BackendCase\\Data\\output.csv";
            using (StreamWriter writer = new StreamWriter(csvFilePath, true))
            {
                writer.WriteLine($"{parts[3]},{parts[4]},{parts[5]}");
            }
            Console.WriteLine("CSV dosyası oluşturuldu.");
        }

    }
}
