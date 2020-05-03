using iFoodieBud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iFoodieBud.Infrastructure
{
    public class DbContextiFoodieBud : DbContext
    {
        public DbContextiFoodieBud(DbContextOptions<DbContextiFoodieBud> options) 
            :base(options) {
        
        }
        public DbSet<Page> Pages { get; set; }
    }
}
