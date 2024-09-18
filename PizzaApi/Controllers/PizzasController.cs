using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzasController : ControllerBase
    {
        private static readonly List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Margherita", Description = "Classic Margherita with fresh basil", Price = 8.99m },
            new Pizza { Id = 2, Name = "Pepperoni", Description = "Spicy pepperoni with mozzarella", Price = 9.99m }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> Get()
        {
            return Ok(Pizzas);
        }

        [HttpPost]
        public ActionResult<Pizza> Post([FromBody] Pizza pizza)
        {
            if (pizza == null)
            {
                return BadRequest();
            }

            pizza.Id = Pizzas.Max(p => p.Id) + 1;
            Pizzas.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }
    }
}
