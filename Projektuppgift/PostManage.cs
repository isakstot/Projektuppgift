﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Projektuppgift
{
    internal class PostManage
    {

        const string folderName = "Posts";
        static string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName;
        string fullPath = projectPath + "\\" + folderName;
        public List<Post> Posts = new List<Post>();

        public void WaitForInput()
        {
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }

        public void ReadPosts()
        {
            var fileCount = (from file in Directory.EnumerateFiles(fullPath, "*.txt", SearchOption.AllDirectories)
                                                         select file).Count();
            foreach (string file in Directory.EnumerateFiles(fullPath, "*.txt", SearchOption.AllDirectories))
            {
                string[] lines = File.ReadAllLines(file);
                string title = lines[0];
                Tags tag = lines[1].ToLower() switch
                {
                    "diary" => Tags.Diary,
                    "note" => Tags.Note,
                    "quote" => Tags.Quote,
                    "poem" => Tags.Poem,
                    _ => Tags.None,
                };
                DateTime date = DateTime.Parse(lines[2]);
                string body = lines[3];
                Post post = new Post(title, date, body, tag);
                Posts.Add(post);
            }
        }

        public void CreatePost()
        {
            string title;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Title of post:");
                title = Console.ReadLine();
                if (title == "")
                {
                    Console.WriteLine("Title can't be empty, try again");
                }
                else if (title.Length > 64)
                {
                    Console.WriteLine("Title can't be longer than 64 characters, try again");
                }
                //regex to check for invalid characters
                else if (!Regex.IsMatch(title, "^[a-zA-Z0-9_-]*$"))
                {
                    Console.WriteLine("Title contains invalid characters");
                }
                else
                {
                    break;
                }
                WaitForInput();
            }
            
            foreach (Post postTitle in Posts)
            {
                if (title == postTitle.Title)
                {
                    Console.WriteLine("Post with that title already exists, try again");
                    WaitForInput();
                    CreatePost();
                }
            }
            DateTime date = DateTime.Now;
            Console.WriteLine("Body of post:");
            string body;
            while (true)
            {
                body = Console.ReadLine();
                if (body == "")
                {
                    Console.WriteLine("Body can't be empty, try again");
                }
                else
                {
                    break;
                }
            }
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
            Console.WriteLine("Post \"" + post.Title + "\" successfully created!");
            //save post to file
            string fileName = post.Title + ".txt";
            string filePath = Path.Combine(fullPath, fileName);
            Console.WriteLine(filePath);
            string fileContent = $"{post.Title}\n{post.Tag}\n{post.Date}\n{post.Body}";
            File.WriteAllText(filePath, fileContent);
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
            
            string postToDelete = Console.ReadLine();
            if (postToDelete == "")
            {
                return;
            }

            //print all post titles
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
                        File.Delete(fullPath + "\\" + post.Title + ".txt");
                        if (File.Exists(fullPath + "\\" + post.Title + ".txt"))
                        {
                            Console.WriteLine("Failed to delete post");
                        }
                        else
                        {
                            Console.WriteLine($"Post \"{post.Title}\" successfully deleted!");

                        }
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
            Console.Clear();
            bool postFound = false;

            switch (searchMethod)
            {
                case "title":
                    SearchByTitle(ref postFound);
                    break;
                case "date":
                    SearchByDate(ref postFound);
                    break;
                case "tag":
                    SearchByTag(ref postFound);
                    break;
            }

            if (!postFound)
            {
                Console.WriteLine("No matching posts found.");
            }

            WaitForInput();
        }

        private void SearchByTitle(ref bool postFound)
        {
            Console.Write("Title to search for:");
            string searchQuery = Console.ReadLine().ToLower();

            foreach (Post post in Posts)
            {
                if (post.Title.ToLower().Contains(searchQuery))
                {
                    postFound = true;
                    Console.WriteLine(post.ToString());
                }
            }
        }

        private void SearchByDate(ref bool postFound)
        {
            Console.Write("Year to search for: ");
            if (!int.TryParse(Console.ReadLine(), out int year))
            {
                Console.WriteLine("Invalid input. Please enter a valid year.");
                return;
            }

            int? month = GetNumericInput("Month (press Enter to skip):");
            int? day = GetNumericInput("Day (press Enter to skip):");

            foreach (Post post in Posts)
            {
                if ((!month.HasValue || post.Date.Month == month) && (!day.HasValue || post.Date.Day == day) && post.Date.Year == year)
                {
                    postFound = true;
                    Console.WriteLine(post.ToString());
                }
            }
        }

        private void SearchByTag(ref bool postFound)
        {
            Console.Write("Available tags: ");
            foreach (Tags tag in Enum.GetValues(typeof(Tags)))
            {
                Console.Write(tag.ToString() + ", ");
            }
            Console.Write("\nTag to search for:");
            string tagInput = Console.ReadLine();

            Tags tagQuery = tagInput.ToLower() switch
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
        }

        private int? GetNumericInput(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            if (!int.TryParse(input, out int result))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return null;
            }

            return result;
        }

        public void PrintPosts()
        {
            Posts.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
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
