using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreestyleApplication.ViewModel
{
    public class UserViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
        public List<CompetitionViewModel> Competitions { get; set; }
    }
}
