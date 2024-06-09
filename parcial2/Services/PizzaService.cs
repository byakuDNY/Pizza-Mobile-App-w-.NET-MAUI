using parcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial2.Services
{
    public class PizzaService
    {
        private readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza
            {
                Name = "pizza1",
                Image = "Resources\\Images\\pizzas.png",
                Price = 10.99
            },
            new Pizza
            {
                Name = "pizza2",
                Image = "Resources\\Images\\pizzas.png",
                Price = 15.10
            },
            new Pizza
            {
                Name = "pizza3",
                Image = "Resources\\Images\\pizzas.png",
                Price = 5.25
            }
        };

        public IEnumerable<Pizza> GetAllPizzas() => _pizzas;

        public IEnumerable<Pizza> GetPopularPizzas(int count = 6) => _pizzas.OrderBy(p => Guid.NewGuid()).Take(count);

        
    }
}
