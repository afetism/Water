using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRemainder.Models
{
    internal struct History
    {
        public History()
        {
            Date =DateTime.Now;
        }
        public History(DateTime date, float dailyWater)
        {
            Date=date;
            DailyWater=dailyWater;
        }

       public DateTime Date { get; set; }

       public float DailyWater { get; set; }


        public override string ToString() =>  $"Date: {Date.ToShortDateString().ToString()} Water : {DailyWater}";
      

    }
}
