using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Poc_Instagram.Models;

namespace Poc_Instagram.Data
{
    public class BdContext : DbContext
    {
        public BdContext (DbContextOptions<BdContext> options)
            : base(options)
        {
        }
        public DbSet<Insight> Insights { get; set; }
        public DbSet<Perfil>? Perfil { get; set; }
    }
}
