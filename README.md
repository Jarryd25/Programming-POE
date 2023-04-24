# Recipe and Ingredients - Console Application
This is a C# console application that allows the user to create a recipe with ingredients and steps, and perform different actions on it such as displaying, scaling, resetting and clearing.

## How to Run
1. Ensure that you have a C# development environment installed on your computer. If not, you can download and install Visual Studio or Visual Studio Code.
2. Download the source code and save it in a directory of your choice.
3. Open the command prompt or terminal and navigate to the directory where the source code is saved.
4. Compile the code by running the following command:
   (*csc MainProgram.cs Recipe.cs*)
   This will generate an executable file named *MainProgram.exe*.
5. Run the executable by typing the following command:
   (*MainProgram.exe*)
6. The program will prompt you to enter the number of ingredients and steps in the recipe. Follow the prompts and enter the information as required.
7. Once the recipe is created, you will be presented with a menu of options:
   
*Enter a command:*
*1. Display recipe*
*2. Scale recipe*
*3. Reset quantities*
*4. Clear recipe*
*5. Exit*

8. Select an option by entering the corresponding number and follow the prompts as required.

## How it Works
The program consists of two classes - Ingredient and Recipe. The Ingredient class represents an ingredient with a name, quantity and unit. The Recipe class represents a recipe with an array of ingredients and an array of steps. The Recipe class also contains methods to display, scale, reset and clear the recipe.

The program starts by creating a Recipe object and prompting the user to enter the number of ingredients and steps in the recipe. The user is then prompted to enter the details of each ingredient and step.

Once the recipe is created, the user is presented with a menu of options to perform different actions on the recipe. The user can choose to display the recipe, scale the recipe by a factor of 0.5, 2 or 3, reset the quantities of the ingredients to their original values, clear the recipe, or exit the program.

When the user selects an option, the program performs the corresponding action and prompts the user for any additional input as required.

Note that the program uses exception handling to ensure that the user enters valid input. If the user enters an invalid input, the program displays an error message and prompts the user to enter the input again.
