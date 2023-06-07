using System;
using System.Collections.Generic;
using System.Linq;

namespace Part2
{
    // Define a class for an ingredient
    class Ingredient
    {
        public string Name { get; set; } // Name of the ingredient
        public double Quantity { get; set; } // Quantity of the ingredient
        public string Unit { get; set; } // Unit of measurement of the ingredient
        public int Calories { get; set; } // Number of calories in the ingredient
        public string FoodGroup { get; set; } // Food group that the ingredient belongs to

        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }
    }

    // Define a class for a recipe
    class Recipe
    {
        private List<Ingredient> ingredients; // List to store the ingredients
        private List<string> steps; // List to store the steps
        public string Name { get; set; } // Name of the recipe

        // Constructor to initialize the recipe and its properties
        public Recipe(string name)
        {
            Name = name;
            ingredients = new List<Ingredient>();
            steps = new List<string>();
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
        }

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            steps.Add(step);
        }

        // Method to calculate and display the total calories of the recipe
        public void DisplayTotalCalories()
        {
            int totalCalories = ingredients.Sum(ingredient => ingredient.Calories);
            Console.WriteLine($"Total calories: {totalCalories}");
            if (totalCalories > 300)
            {
                Console.WriteLine("Warning: This recipe exceeds 300 calories.");
            }
        }

        // Method to display the recipe in a neat format
        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Recipe: {Name}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingredients:");
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }
    }

    class MainProgram
    {
        static List<Recipe> recipes = new List<Recipe>(); // List to store recipes

        // Delegate to notify the user when a recipe exceeds 300 calories
        delegate void RecipeCaloriesExceeded(string recipeName);

        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                // Gives the user choices
                Console.WriteLine("\nEnter a command:");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Select a recipe to display");
                Console.WriteLine("4. Exit");

                string input = Console.ReadLine();

                // The different cases are based on the user's input
                switch (input)
                {
                    case "1":
                        CreateRecipe();
                        break;
                    case "2":
                        DisplayAllRecipes();
                        break;
                    case "3":
                        SelectRecipe();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }

        // Method to create a new recipe
        static void CreateRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Recipe recipe = new Recipe(name);

            Console.Write("Enter the number of ingredients: ");
            int numIngredients = ReadIntegerInput();

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Ingredient #{i + 1}:");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = ReadDoubleInput();
                Console.Write("Unit: ");
                string unit = Console.ReadLine();
                Console.Write("Calories: ");
                int calories = ReadIntegerInput();
                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();

                Ingredient ingredient = new Ingredient(ingredientName, quantity, unit, calories, foodGroup);
                recipe.AddIngredient(ingredient);
            }

            Console.Write("Enter the number of steps: ");
            int numSteps = ReadIntegerInput();

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Step #{i + 1}:");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            recipes.Add(recipe);
        }

        // Method to display all recipes in alphabetical order by name
        static void DisplayAllRecipes()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
            }
            else
            {
                Console.WriteLine("Recipes:");
                List<string> recipeNames = recipes.Select(recipe => recipe.Name).OrderBy(name => name).ToList();
                foreach (string name in recipeNames)
                {
                    Console.WriteLine(name);
                }
            }
        }

        // Method to select and display a specific recipe
        static void SelectRecipe()
        {
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();

            Recipe selectedRecipe = recipes.FirstOrDefault(recipe => recipe.Name == name);

            if (selectedRecipe != null)
            {
                selectedRecipe.Display();
                selectedRecipe.DisplayTotalCalories();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        // Helper method to read integer input from the user
        static int ReadIntegerInput()
        {
            int result;
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
            }
        }

        // Helper method to read double input from the user
        static double ReadDoubleInput()
        {
            double result;
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
