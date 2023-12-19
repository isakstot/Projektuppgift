using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projektuppgift
{
    internal class PostManage
    {
        public List<Post> Posts = new List<Post>();

        public void CreatePost()
        {
            Console.WriteLine("Title of post:");
            string title = Console.ReadLine();
            DateTime date = DateTime.Now;
            Console.WriteLine("Body of post:");
            string body = Console.ReadLine();
            Post post = new Post(title, date, body);
            Posts.Add(post);
        }

        public void DeletePost() 
        {
        
        }

        public void SearchPost()
        {

        }
    }
}
