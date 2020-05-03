using System.Collections.Generic;

namespace iFoodieBud.Models
{
    public class HealthLabel
    {
        public int HealthLabelId { get; set; }
        public string Name { get; set; }

        public int DishId { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}