using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRemainder.Models
{
    internal class User
    {
        public User(string name, string email, string password, float weight)
        {
            Name=name;
            Email=email;
            Password=password;
            Weight=weight;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public float Weight { get; set; }

        public List<History> HistoriesDaily { get; set; }

        public float CurrentWater { get; set; }
        public float AvarageDailyWater() => Weight * 20;










    }
}
