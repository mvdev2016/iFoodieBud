using System.Collections.Generic;

namespace iFoodieBud.Models
{
    public class DietLabel
    {
        public int DietLabelId { get; set; }
        public string Name { get; set; }
        public int DishId { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}