using System;

namespace GenericList
{
    public static class GenericListCompare
    {
        public static T Min<T>(this GenericList<T> list)
            where T : IComparable<T>
        {
            T min = list[0];
            for (uint i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(min) < 0)
                {
                    min = list[i];
                }
            }
            return min;
        }
        public static T Max<T>(this GenericList<T> list)
            where T : IComparable<T>
        {
            T max = list[0];
            for (uint i = 0; i < list.Count; i++)
            {
                if (list[i].CompareTo(max) > 0)
                {
                    max = list[i];
                }
            }
            return max;
        }
    }
}
