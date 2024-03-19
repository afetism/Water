using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRemainder.Helper
{
    internal static class CheckAndCasting
    {

       public  static float GetDoubleFromString(string? input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (double.TryParse(input, out float value))
                    return value;
                else throw new InvalidCastException("Can't casting To double");
            }
            else
                throw new NullReferenceException("Invalid Data(Null or white Space)");
        }

       public static bool CheckString(string input)
        {
            if (!string.IsNullOrWhiteSpace(input)) return true;
            else throw new NullReferenceException();
        }



    }
}
