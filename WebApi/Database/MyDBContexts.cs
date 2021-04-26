using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model;

namespace WebApi.Database
{
    public class MyDBContexts : DbContext
    {
        public DbSet<Regions> Regions { get; set; }

        public DbSet<Country> Countries { get; set; }


        public MyDBContexts(DbContextOptions<MyDBContexts> options) : base(options)
        {

        }
    }
}
