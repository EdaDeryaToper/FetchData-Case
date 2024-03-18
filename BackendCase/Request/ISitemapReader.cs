namespace BackendCase.Request
{
    public interface ISitemapReader
    {
        string[] ReadSitemap(string path);
        void ReadDoctorUrl(string[] urls);
    }
}
