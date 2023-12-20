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
            Console.Clear();
            Console.WriteLine("Title of post:");
            string title = Console.ReadLine();
            DateTime date = DateTime.Now;
            Console.WriteLine("Body of post:");
            string body = Console.ReadLine();
            Console.WriteLine("Tag of post (diary, note, quote, poem) or leave empty for none:");
            Tags tag = Console.ReadLine().ToLower() switch
            {
                "diary" => Tags.Diary,
                "note" => Tags.Note,
                "quote" => Tags.Quote,
                "poem" => Tags.Poem,
                _ => Tags.None,
            };
            Post post = new Post(title, date, body, tag);
            Posts.Add(post);
            Console.Clear();
            Console.WriteLine("Post \"" + post.Title + "\" successfully created!");
            WaitForInput();
        }

        public void DeletePost()
        {
            bool postFound = false;

            Console.Clear();

            Console.WriteLine("Posts available:");
            foreach (Post post in Posts)
            {
                Console.WriteLine(post.Title);
            }
            Console.WriteLine("Name of post to delete (leave empty to cancel):");
            //print all post titles
            
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
                    //take confirmation
                    Console.WriteLine($"Are you sure you want to delete \"{post.Title}\"? (y/n)");
                    string confirmation = Console.ReadLine();
                    if (confirmation == "y")
                    {
                        Posts.Remove(post);
                        Console.WriteLine($"Post \"{post.Title}\" successfully deleted!");
                        WaitForInput();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!postFound)
            {
                Console.WriteLine($"Post \"{postToDelete}\" not found, try again");
                WaitForInput();
                DeletePost();
            }
        }

        public void SearchPost(string searchMethod)
        {
            bool postFound = false;

            Console.Clear();
            switch (searchMethod)
            {
                case "title":
                    Console.WriteLine("Title to search for:");
                    string searchQuery = Console.ReadLine().ToLower();
                    foreach (Post post in Posts)
                    {
                        if (post.Title.ToLower().Contains(searchQuery))
                        {
                            postFound = true;
                            Console.WriteLine(post.ToString());
                        }
                    }
                    if (!postFound)
                    {
                        Console.WriteLine($"No posts found containing \"{searchQuery}\"");
                    }
                    WaitForInput();
                    break;
                case"date":
                    //search function for year, month and date
                    bool monthEmpty = false;
                    bool dayEmpty = false;
                    Console.Write("Year to search for: ");
                    int year = int.Parse(Console.ReadLine());

                    Console.Write("Month: ");
                    string monthInput = Console.ReadLine();
                    int month;
                    if (monthInput == "")
                    {
                        monthEmpty = true;
                        month = 1;
                    }
                    else
                    {
                        month = int.Parse(monthInput);
                    }
                    if (monthEmpty)
                    {
                        foreach (Post post in Posts)
                        {
                            if (post.Date.Year == year)
                            {
                                postFound = true;
                                Console.WriteLine(post.ToString());
                            }
                        }
                    }
                    else
                    {
                        Console.Write("Day: ");
                        string dayInput = Console.ReadLine();
                        int day;
                        if (dayInput == "")
                        {
                            dayEmpty = true;
                            day = 1;
                        }
                        else
                        {
                            day = int.Parse(dayInput);
                        }
                        
                        if (dayEmpty)
                        {
                            foreach (Post post in Posts)
                            {
                                if (post.Date.Year == year && post.Date.Month == month)
                                {
                                    postFound = true;
                                    Console.WriteLine(post.ToString());
                                }
                            }
                        }
                        else
                        {
                            foreach (Post post in Posts)
                            {
                                if (post.Date.Year == year && post.Date.Month == month && post.Date.Day == day)
                                {
                                    postFound = true;
                                    Console.WriteLine(post.ToString());
                                }
                            }
                        }
                    }

                    if (!postFound)
                    {
                        Console.WriteLine($"No posts found from that date.");
                    }
                    WaitForInput();
                    break;
                case "tag":
                    string tagInput = Console.ReadLine().ToLower();
                    Tags tagQuery = tagInput switch
                    {
                        "diary" => Tags.Diary,
                        "note" => Tags.Note,
                        "quote" => Tags.Quote,
                        "poem" => Tags.Poem,
                        _ => Tags.None,
                    };

                    foreach (Post post in Posts)
                    {
                        if (post.Tag == tagQuery)
                        {
                            postFound = true;
                            Console.WriteLine(post.ToString());
                        }
                    }
                    if(!postFound)
                    {
                        Console.WriteLine($"No posts found with tag \"{tagInput}\"");
                    }
                    WaitForInput();
                    break;
            }
        }

        public void PrintPosts()
        {
            Console.Clear();
            foreach (Post post in Posts)
            {
                Console.WriteLine(post.ToString());
                Console.WriteLine();
            }
            WaitForInput();
        }
    }
}
