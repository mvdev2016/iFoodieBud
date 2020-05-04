using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iFoodieBud.Models
{
    public class Dish
    {
        public int DishId { get; set; }

        [Required]
        [Display(Name = "Dish Name")]
        public string Name { get; set; }


        [Display(Name ="Description")]
        public string Description { get; set; }

        public string Slug { get; set; }

      
        public string Image { get; set; }
        public float? Calories { get; set; }
        public ICollection<DishIngredients> DishIngredients { get; set; }

        public int DietLabelId { get; set; }
        public DietLabel DietLabel { get; set; }

        public int HealthLabelId { get; set; }
        public HealthLabel HealthLabel { get; set; }
    }
}
