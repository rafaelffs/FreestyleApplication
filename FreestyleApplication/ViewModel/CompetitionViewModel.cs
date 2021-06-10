using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreestyleApplication.ViewModel
{
    public class CompetitionViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<UserViewModel> Users { get; set; }
    }
}
