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

        public void WaitForInput()
        {
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }
        public void CreatePost()
        {
            System.Console.Clear();
            Console.WriteLine("Title of post:");
            string title = Console.ReadLine();
            DateTime date = DateTime.Now;
            Console.WriteLine("Body of post:");
            string body = Console.ReadLine();
            Post post = new Post(title, date, body);
            Posts.Add(post);
            System.Console.Clear();
            Console.WriteLine("Post \"" + post.Title + "\" successfully created!");
            WaitForInput();
        }

        public void DeletePost()
        {
            bool postFound = false;
            Console.WriteLine("Name of post to delete (leave empty to cancel):");
            string postToDelete = Console.ReadLine();
            if (postToDelete == "")
            {
                return;
            }
            foreach (Post post in Posts)
            {
                if (post.Title == postToDelete)
                {
                    postFound = true;
                    Console.WriteLine("Are you sure you want to delete?");
                    //take yes / no input

                    Posts.Remove(post);
                    Console.WriteLine("Post \"" + post.Title + "\" successfully deleted!");
                    WaitForInput();
                    break;
                }
            }
            if (!postFound)
            {
                Console.WriteLine("Post not found, try again");
                DeletePost();
            }
        }

        public void SearchPost(string searchMethod)
        {
            System.Console.Clear();
            switch (searchMethod)
            {
                case "title":
                    Console.WriteLine("Title to search for:");
                    string searchQuery = Console.ReadLine().ToLower();
                    foreach (Post post in Posts)
                    {
                        if (post.Title.ToLower().Contains(searchQuery))
                        {
                            Console.WriteLine(post.ToString()); 
                        }
                    }
                    WaitForInput();
                    break;
                case "date":
                    Console.WriteLine("Date");
                    break;
                case "tag":
                    Console.WriteLine("Tag");
                    break;
            }
        }

        public void PrintPosts()
        {
            System.Console.Clear();
            foreach (Post post in Posts)
            {
                Console.WriteLine(post.ToString());
                Console.WriteLine();
            }
            WaitForInput();
        }

    }
}
