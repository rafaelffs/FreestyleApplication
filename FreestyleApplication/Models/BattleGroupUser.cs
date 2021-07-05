using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreestyleApplication.Models
{
    public class BattleGroupUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int BattleGroupId { get; set; }
        public BattleGroup BattleGroup { get; set; }
        public int Score { get; set; }
    }
}
