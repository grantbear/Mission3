// Grant Beardall
// Section 004
// Mission 3 - Food Bank Inventory System

using Mission3;
using System;
using System.Collections.Generic;

class Program
{
    // Global inventory list
    static List<FoodItem> inventory = new List<FoodItem>();

    static void Main(string[] args)
    {
        int option = 0;

        // Main program loop
        while (option != 4)
        {
            Console.WriteLine("\nWelcome to the Food Bank Inventory Management System!");
            Console.WriteLine("1. Add a Food Item");
            Console.WriteLine("2. Delete a Food Item");
            Console.WriteLine("3. Print a list of current Food Items");
            Console.WriteLine("4. Exit the program");
            Console.Write("Please enter the number that correlates with your desired command: ");

            // Validate Option Selected
            if (int.TryParse(Console.ReadLine(), out option) && option >= 1 && option <= 4)
            {
                switch (option)
                {
                    case 1:
                        AddFoodItem();
                        break;
                    case 2:
                        DeleteFoodItem();
                        break;
                    case 3:
                        PrintFoodItems();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
            }
        }
    }

    // Add Food Item Method
    static void AddFoodItem()
    {
        try
        {
            Console.Write("Enter the name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the category: ");
            string category = Console.ReadLine();

            Console.Write("Enter the quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Must be a positive number.");
                return;
            }

            Console.Write("Enter the expiration date (MM/DD/YYYY): ");
            string date = Console.ReadLine();

            FoodItem newItem = new FoodItem(name, category, quantity, date);
            inventory.Add(newItem); // Add to inventory
            Console.WriteLine("Food item added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Delete Food Item Method
    static void DeleteFoodItem()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("The inventory is empty. Nothing to delete.");
            return;
        }

        Console.WriteLine("Enter the name of the food item to delete: ");
        string nameToDelete = Console.ReadLine();

        // Find the item in the inventory
        FoodItem itemToDelete = inventory.Find(item => item.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

        if (itemToDelete != null)
        {
            inventory.Remove(itemToDelete);
            Console.WriteLine($"Food item '{nameToDelete}' has been deleted.");
        }
        else
        {
            Console.WriteLine($"No food item with the name '{nameToDelete}' found.");
        }
    }

    // Print Food Items Method
    static void PrintFoodItems()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("The inventory is currently empty.");
            return;
        }

        Console.WriteLine("\nCurrent Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
