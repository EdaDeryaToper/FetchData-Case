using System.Xml.Serialization;

namespace BackendCase.Models.Response
{
    
        [XmlRoot(ElementName = "sitemap")]
        public class Sitemap
        {

            [XmlElement(ElementName = "loc")]
            public string Loc { get; set; }

            [XmlElement(ElementName = "lastmod")]
            public DateTime Lastmod { get; set; }
        }

    [XmlRoot(ElementName = "sitemapindex", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class Sitemapindex
        {

            [XmlElement(ElementName = "sitemap")]
            public List<Sitemap> Sitemap { get; set; }

            [XmlAttribute(AttributeName = "xsi")]
            public string Xsi { get; set; }

            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }

            [XmlAttribute(AttributeName = "schemaLocation")]
            public string SchemaLocation { get; set; }

            [XmlText]
            public string Text { get; set; }
        }

    
}
