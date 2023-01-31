using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            // var user = new User
            // {
            //     Name = "André Fulano",
            //     Slug = "andrefulano",
            //     Email = "an@Cicrano.com",
            //     Bio = "aa",
            //     Github = "gulanogithub",
            //     Image = "https://fulano.png",
            //     PasswordHash = "123091237"
            // };

            using var context = new BlogDataContext();
            // context.Users.Add(user);
            var test = context.Users.FirstOrDefault();
            Console.WriteLine(test.Name);
        }
    }
}
