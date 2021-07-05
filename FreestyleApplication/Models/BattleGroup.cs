using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreestyleApplication.Models
{
    public class BattleGroup
    {
        public int Id { get; set; }
        public Group Group { get; set; }
        public List<BattleGroupUser> BattleGroupUsers { get; set; }
    }
}
