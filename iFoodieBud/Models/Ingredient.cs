using System.Collections.Generic;

namespace iFoodieBud.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; }

        public List<DishIngredients> DishIngredients  { get; set; }
    }
}