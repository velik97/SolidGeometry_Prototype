using System;
using System.Linq;

namespace Util
{
    public static class EnumUtils
    {
        public static int GetMaxValue<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Max();
        }
        
        public static int GetMinValue<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<int>().Min();
        }

        public static TEnum GetNextValue<TEnum>(this TEnum value) where TEnum : Enum
        {
            bool isFlag = typeof(TEnum).HasAttribute<FlagsAttribute>();
            int v = (int) (object) value;
            if (isFlag)
            {
                v = v == 0 ? 1 : v * 2;
                if (v > GetMaxValue<TEnum>())
                {
                    v = 0;
                }
            }
            else
            {
                v = (v + 1) % GetMaxValue<TEnum>();
            }
            return (TEnum) (object) v;
        }
    }
}