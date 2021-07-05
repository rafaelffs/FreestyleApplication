using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FreestyleApplication.Models
{
    public class GroupUser
    {
        public Group Group { get; set; }
        public User User { get; set; }
    }
}
