using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
    }
}
