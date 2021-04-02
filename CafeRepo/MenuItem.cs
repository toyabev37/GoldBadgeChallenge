﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }        
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public MenuItem()
        {

        }

        public MenuItem (string mealName, string description, string ingredients, double price)
        {

            
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
