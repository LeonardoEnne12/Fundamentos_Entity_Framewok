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
            using var context = new BlogDataContext();

            // context.Users.Add(     
            // new User
            // {
            //     Name = "André Cicrano",
            //     Slug = "andrecicrano",
            //     Email = "andre@Cicrano.com",
            //     Bio = "20x Microsoft MVP",
            //     Image = "https://cicrano.png",
            //     PasswordHash = "123091237"
            // });

            // context.SaveChanges();

            var user = context.Users.FirstOrDefault();
            var post = new Post{
                Title = "Meu artigo",
                Summary = "Neste artigo vamos conferir...",
                Body = "Meu artigo",
                Slug = "meu-artigo",
                CreateDate = System.DateTime.Now,
                Category = new Category
                {
                    Name = "Frontend",
                    Slug = "frontend"
                },
                Author = user,
                // LastUpdateDate = ,
                // Tags = null,
            };

            context.Posts.Add(post);
            context.SaveChanges();


        }
    }
}
