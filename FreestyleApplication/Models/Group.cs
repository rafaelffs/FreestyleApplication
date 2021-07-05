using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreestyleApplication.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Competition Competition { get; set; }
        public List<User> Users { get; set; }
    }
}
