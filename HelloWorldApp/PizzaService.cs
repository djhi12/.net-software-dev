using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorldApp
{
    // Define the Pizza model
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
    }

    // Define the PizzaService class for managing pizzas
    public static class PizzaService
    {
        // Static list of pizzas
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;

        // Initialize the list with some pizzas
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie Delight", IsGlutenFree = true }
            };
        }

        // Method to get all pizzas
        public static List<Pizza> GetAll() => Pizzas;

        // Method to get a pizza by ID
        public static Pizza Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

        // Method to add a new pizza
        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        // Method to delete a pizza
        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        // Method to update an existing pizza
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}
