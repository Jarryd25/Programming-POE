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
                double quantity = 0;
                try
                {
                    quantity = double.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    i--;
                    continue;
                }
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
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset the ingredient quantities to their original values
        public void Reset()
        {
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity /= 2; // Divide by 2 to reset to original value
            }
        }

        // Method to clear all the data in the recipe
        public void Clear()
        {
            Array.Clear(ingredients, 0, ingredients.Length);
            Array.Clear(steps, 0, steps.Length);
        }
    }

    class MainProgram
    {
       static void Main(string[] args)
       {
            Recipe recipe = new Recipe();

            while (true)
            {
                //Gives the user choices
                Console.WriteLine("\nEnter a command:");
                Console.WriteLine("1. Display recipe");
                Console.WriteLine("2. Scale recipe");
                Console.WriteLine("3. Reset quantities");
                Console.WriteLine("4. Clear recipe");
                Console.WriteLine("5. Exit");

                string input = Console.ReadLine();

                //The different cases are based on the user's input
                switch (input)
                {
                    case "1":
                        recipe.Display();
                        break;
                    case "2":
                        Console.Write("Enter scale factor (0.5, 2, or 3): ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.Scale(factor);
                        Console.WriteLine($"Recipe scaled by a factor of {factor}");
                        break;
                    case "3":
                        recipe.Reset();
                        Console.WriteLine("Quantities reset to original values");
                        break;
                    case "4":
                        recipe.Clear();
                        Console.WriteLine("Recipes have been cleared");
                        break;
                    case "5":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                }
            }
       }
    }
}