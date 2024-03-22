using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterRemainder.Helper
{
    internal static class CheckAndCasting
    {

       public  static float GetFloatFromString(string? input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (float.TryParse(input, out float value))
                    return value;
                else throw new InvalidCastException("Can't casting To double");
            }
            else
                throw new NullReferenceException("Invalid Data(Null or white Space)");
        }
        public static int GetIntFromString(string? input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                if (int.TryParse(input, out int value))
                    return value;
                else throw new InvalidCastException("Can't casting To Int");
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
