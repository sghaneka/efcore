using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace SomeUI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            _context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
            // InsertSamurai();
            // InsertMultipleSamurais();
            MoreQueries();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        static void MoreQueries()
        {
            var name = "Sampson";
            var samurais = _context.Samurais.Where(s => s.Name == name).ToList();
            var x = _context.Samurais.FirstOrDefault(s => s.Name == "Julie");
        }

        static void SimpleSamuraiQuery()
        {
            using (var context = new SamuraiContext())
            {
                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                var samurais = context.Samurais.ToList();
            }
        }

        static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Julie" };
            var samuraiSammy = new Samurai() { Name = "Sampson" };
            using (var context = new SamuraiContext())
            {
                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                context.Samurais.Add(samurai);
                context.Samurais.Add(samuraiSammy);
                context.SaveChanges();
                //context.Add(samurai);
            }
        }

        static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Julie" };
            using (var context = new SamuraiContext())
            {
                context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());
                context.Samurais.Add(samurai);
                context.SaveChanges();
                //context.Add(samurai);
            }
        }
    }
}