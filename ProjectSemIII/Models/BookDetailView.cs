using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSemIII.Models
{
    public class BookDetailView
    {
        public string BookId  { get; set; }
        public string Category { get; set; }
        public string  AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string BookName { get; set; }
        public int? PublishingYear { get; set; }
        public float? Price { get; set; }
        public  int? Sale { get; set; }
        public string Descriptions { get; set; }
        public string BookImage1 { get; set; }
        public string BookImage2 { get; set; }
        public string BookImage3 { get; set; }
        public int StatusVarible { get; set; }
        public int StatusOn { get; set; }
    }
}