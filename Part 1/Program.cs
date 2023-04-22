using System;

namespace RecipeAndIngredients
{
    // Define a class for an ingredient
    class Ingredient
    {
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement of the ingredient
    }

    // Define a class for a recipe
    class Recipe
    {
        private Ingredient[] ingredients; // Array to store the ingredients
        private string[] steps; // Array to store the steps
    }
}