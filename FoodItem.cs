using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3
{
    public class FoodItem
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string ExpirationDate { get; set; }

        // Constructor
        public FoodItem(string name, string category, int quantity, string expirationDate)
        {
            // Validate the user inputs
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Category cannot be empty.");
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be a positive number.");
            }

            // Assign values to the properties
            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        // Override ToString() to provide a formatted string for each FoodItem
        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate}";
        }
    }
}
