using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iFoodieBud.Models
{
    public class DishIngredients
    {
        [Key]
        public int DishIngredientsId { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
