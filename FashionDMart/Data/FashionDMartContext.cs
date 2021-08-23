using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FashionDMart.Models;

namespace FashionDMart.Data
{
    public class FashionDMartContext : DbContext
    {
        public FashionDMartContext (DbContextOptions<FashionDMartContext> options)
            : base(options)
        {
        }

        public DbSet<FashionDMart.Models.Designer> Designer { get; set; }

        public DbSet<FashionDMart.Models.DCollections> DCollections { get; set; }

        public DbSet<FashionDMart.Models.Order> Order { get; set; }
    }
}
