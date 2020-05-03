using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iFoodieBud.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public float Calories { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<DietLabel> DietLabels { get; set; }
        public List<HealthLabel> HealthLabels { get; set; }
    }
}
