using System;
using System.Collections.Generic;
using System.Text;

namespace FruitVice_API_Services_Data.Models
{
    public class FruityViceResponseModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Family { get; set; }
        public string order { get; set; }
        public string genus { get; set; }
        public Nutritions Nutritions { get; set; }

    }
    public class Nutritions
    {
        public int Calories { get; set; }
        public decimal Fat { get; set; }
        public decimal Sugar { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Protein { get; set; }
    }
}
