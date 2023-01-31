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
            using(var context = new BlogDataContext())
            {
                // var tag = new Tag{Name = ".NET", Slug = "dotnet"};
                // context.Tags.Add(tag);
                // context.SaveChanges();

                // var tag = new Tag{Name = "ASP.NET", Slug = "aspnet"};
                // context.Tags.Add(tag);
                // context.SaveChanges();

                // var tag = context.Tags.FirstOrDefault( x=>x.Id == 1);
                // tag.Name = ".Net";
                // tag.Slug = "dotnet";
                // context.Update(tag);
                // context.SaveChanges();

                // var tag = context.Tags.FirstOrDefault( x=>x.Id == 1);
                // context.Remove(tag);
                // context.SaveChanges();

                // var tags = context.Tags.AsNoTracking().ToList(); // No ToList() aqui vc está executando a query trazendo pra memória 
                //                                   // ToList sempre no final para trazer só o essencial
                //                                   // AsNoTracking() Para não trazer informações adicionais "metadados" que são utilizados pra 
                //                                   // UPDATE e DELETE
                // foreach(var tag in tags)//Sem ToList() aqui vc está executando a query
                // {
                //     Console.WriteLine(tag.Name);
                // }

                var tag = context.Tags.AsNoTracking().FirstOrDefault( x=>x.Id == 3);// No FirstOrDefault aqui vc está executando a query
                Console.WriteLine(tag?.Name); // tag?.Name null save              


            }
        }
    }
}
