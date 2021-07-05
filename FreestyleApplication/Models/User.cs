using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreestyleApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public List<Competition> Competitions { get; set; }
        public List<Group> Groups { get; set; }
        public List<BattleGroupUser> BattleGroupUsers { get; set; }
    }
}
