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
            Date= DateTime.Now;
            DailyWater=0;
        }

        DateTime Date { get; set; }

        float DailyWater {  get; set; }

         void EndDay(float dailyWater)
        {
            DailyWater=dailyWater;
            Date.AddDays(1);
        }

    }
}
