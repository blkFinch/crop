
using System;

namespace UtilityExtensions{

    public static class Extensions
    {

        /*
            This is for scrolling through the player equip states. It iterates through
            the enum and cycles around to 0 if it reaches the end. 
            This code was written by : husayt on stack overflow
                https://stackoverflow.com/questions/642542/how-to-get-next-or-previous-enum-value-in-c-sharp
        */
        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length==j) ? Arr[0] : Arr[j];            
        }
    }
}

