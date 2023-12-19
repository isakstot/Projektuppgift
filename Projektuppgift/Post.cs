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

        public Post(string title, DateTime date, string body) 
        {
            Title = title;
            Date = date;
            Body = body;
        }
        
        public override string ToString()
        {
            return $"Title: {Title}\nDate: {Date}\nBody: {Body}";
        }
    }
}
