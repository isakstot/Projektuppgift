using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    internal class Post
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public Tags Tag { get; set; }

        public Post(string title, DateTime date, string body, Tags tag) 
        {
            Tag = tag;
            Title = title;
            Date = date;
            Body = body;
        }
        
        public override string ToString()
        {
            return $"Title: {Title} \nTag: {Tag}\nDate: {Date.ToString("yyyy-MM-dd")}\nBody: {Body}";
        }
    }
}
