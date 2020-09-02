using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Models;

namespace MyFirstAPI.Controllers
{
    [Route("api/pizzas")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        static List<Pizza> _pizzas;

        // when a constructor is mark as static, it only gets called once
        static PizzasController()
        {
            var pizza = new Pizza { Id = 1, Size = "Medium", Toppings = new List<string> { "Beef" } };
            var pizza2 = new Pizza { Id = 2, Size = "Medium", Toppings = new List<string> { "Cheese" } };
            var pizza3 = new Pizza { Id = 3, Size = "Medium", Toppings = new List<string> { "Bacon" } };

            _pizzas = new List<Pizza> { pizza, pizza2, pizza3 };
        }

        [HttpGet]
        public List<Pizza> GetAllPizzas()
        {
            return _pizzas;
        }


        // api/pizzas/{id}
        // api/pizzas/2
        [HttpGet("{id}")]
        public IActionResult GetPizzaById(int id)
        {
            var result = _pizzas.SingleOrDefault(pizza => pizza.Id == id);

            if (result == null)
            {
                return NotFound($"Could not find a pizza with the Id of {id}");
            }


            return Ok(result);
        }



        // if your making a controller, you need to use 'IActionResult'

        //when doing a POST...
        // it needs to be in body of post
        // it has to be an object
        // take in a post method with the least amount of info needed

        //api/pizzas
        [HttpPost]
        public IActionResult CreatePizza(CreatePizzaCommand command)
        {
            var newPizza = new Pizza { Size = command.Size };
            newPizza.Id = _pizzas.Select(p => p.Id).Max() + 1;

            _pizzas.Add(newPizza);

            return Created($"api/pizzas/{newPizza.Id}", newPizza);
        }





    }
}
