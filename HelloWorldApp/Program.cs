using System;
using System.Collections.Generic;

namespace HelloWorldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pizza Manager!");

            // Display all pizzas
            List<Pizza> pizzas = PizzaService.GetAll();
            Console.WriteLine("Current Pizzas:");
            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"ID: {pizza.Id}, Name: {pizza.Name}, Gluten-Free: {pizza.IsGlutenFree}");
            }

            // Add a new pizza
            var newPizza = new Pizza { Name = "BBQ Chicken", IsGlutenFree = false };
            PizzaService.Add(newPizza);
            Console.WriteLine("\nAdded new pizza: BBQ Chicken");

            // Display updated pizza list
            pizzas = PizzaService.GetAll();
            Console.WriteLine("\nUpdated Pizzas List:");
            foreach (var pizza in pizzas)
            {
                Console.WriteLine($"ID: {pizza.Id}, Name: {pizza.Name}, Gluten-Free: {pizza.IsGlutenFree}");
            }
        }
    }
}
