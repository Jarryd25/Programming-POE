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

        // Constructor to initialize the arrays based on user input
        public Recipe()
        {
            Console.Write("Enter the number of ingredients: ");
            int numIngredients = int.Parse(Console.ReadLine());

            ingredients = new Ingredient[numIngredients];
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient #{i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = int.Parse(Console.ReadLine());

            steps = new string[numSteps];
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Step #{i + 1}:");
                steps[i] = Console.ReadLine();
            }
        }

        // Method to display the recipe in a neat format
        public void Display()
        {
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe by a given factor
        public void Scale(double factor)
        {
            
        }

        // Method to reset the ingredient quantities to their original values
        public void Reset()
        {
            
        }

        // Method to clear all the data in the recipe
        public void Clear()
        {

        }
    }

}