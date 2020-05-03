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
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DietLabel> DietLabels { get; set; }

        public DbSet<DishIngredients> DishIngredients { get; set; }
        public DbSet<HealthLabel> HealthLabels { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
