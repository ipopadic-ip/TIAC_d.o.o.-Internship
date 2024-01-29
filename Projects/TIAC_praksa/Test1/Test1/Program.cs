using System;
using System.Collections.Generic;
using System.Linq;
using Test1;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<FoodItem> foods = new List<FoodItem>
        {
                new FoodItem { Name = "Pizza", Price = 12.9 },
                new FoodItem { Name = "Burger", Price = 8.4 },
                new FoodItem { Name = "Salad", Price = 6.7 },
                new FoodItem { Name = "Ice Cream", Price = 3.9 }
        };

            Console.WriteLine("Foods and their prices:");

            for (int i = 0; i < foods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Food: {foods[i].Name}, Price: {foods[i].Price:C}");
            }

            double totalCost = 0;
            Dictionary<FoodItem, int> order = new Dictionary<FoodItem, int>();

            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            while (true)
            {
                Console.Write("Select a food by entering the number (0 to finish): ");

                
                //string input = Console.ReadLine();

                try{
                    int selectedNumber = int.Parse(Console.ReadLine());

                    if (selectedNumber == 0)
                    {
                        Console.WriteLine($"Order for {userName}:");
                        foreach (var item in order)
                        {
                            Console.WriteLine($"Food: {item.Key.Name}, Quantity: {item.Value}, Price: {item.Key.Price:C}");
                            totalCost += item.Key.Price * item.Value;
                        }

                        Console.WriteLine($"Total Cost for {userName}: {totalCost:C}");


                        Console.Write("Do you want to remove an item from your order? (yes/no): ");
                        string removeChoice = Console.ReadLine().ToLower();

                        if (removeChoice == "yes")
                        {
                            Console.WriteLine("Your current order:");

                            int index = 1;
                            foreach (var item in order)
                            {
                                Console.WriteLine($"{index}. Food: {item.Key.Name}, Quantity: {item.Value}, Price: {item.Key.Price:C}");
                                index++;
                            }

                            Console.Write("Enter the number of the item you want to remove: ");
                            int itemNumberToRemove = int.Parse(Console.ReadLine()) - 1;

                            if (itemNumberToRemove >= 0 && itemNumberToRemove < order.Count)
                            {
                                FoodItem itemToRemove = order.Keys.ToArray()[itemNumberToRemove];
                                totalCost -= itemToRemove.Price * order[itemToRemove];
                                order.Remove(itemToRemove);
                            }
                            else
                            {
                                Console.WriteLine("Invalid item number.");
                            }
                        }
                        Console.WriteLine("Updated order:");
                        foreach (var item in order)
                        {
                            Console.WriteLine($"Food: {item.Key.Name}, Quantity: {item.Value}, Price: {item.Key.Price:C}");
                        }


                        break;
                    }
                    else if (selectedNumber >= 1 && selectedNumber <= foods.Count)
                    {
                        FoodItem selectedFood = foods[selectedNumber - 1];

                        if (!order.ContainsKey(selectedFood))
                        {
                            order[selectedFood] = 1;
                        }
                        else
                        {
                            order[selectedFood]++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number or '0' to finish.");
                }
            }

            Console.ReadLine();
        }
    }
}
