using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ExtendIEnumerable
{
    // In add and product extension methods, use delegete function, that have to be inserted from user
    public static T Sum<T>(this IEnumerable<T> collection, Func<T, T, T> add)
    {
        if (collection.Count() > 0)
        {
            IEnumerator<T> en = collection.GetEnumerator();
            en.MoveNext();
            T result = en.Current;
            while (en.MoveNext())
            {
                result = add(result, en.Current);
            }
            return result;
        }
        else
        {
            throw new ArgumentException("Empty IEnumerable");
        }
    }
    public static T Product<T>(this IEnumerable<T> collection, Func<T, T, T> product)
    {
        if (collection.Count() > 0)
        {
            IEnumerator<T> en = collection.GetEnumerator();
            en.MoveNext();
            T result = en.Current;
            while (en.MoveNext())
            {
                result = product(result, en.Current);
            }
            return result;
        }
        else
        {
            throw new ArgumentException("Empty IEnumerable");
        }
    }
    public static T Average<T>(this IEnumerable<T> collection, Func<T, T, T> add, Func<T, int, T> divide)
    {
        int count = collection.Count();
        if (count > 0)
        {
            IEnumerator<T> en = collection.GetEnumerator();
            en.MoveNext();
            T result = en.Current;
            while (en.MoveNext())
            {
                result = add(result, en.Current);
            }
            return divide(result,count);
        }
        else
        {
            throw new ArgumentException("Empty IEnumerable");
        }
    }
    public static T MinExt<T>(this IEnumerable<T> collection)
        where T : IComparable<T>
    {
        if (collection.Count() > 0)
        {
            IEnumerator<T> en = collection.GetEnumerator();
            en.MoveNext();
            T min = en.Current;
            while (en.MoveNext())
            {
                if (en.Current.CompareTo(min) < 0)
                {
                    min = en.Current;
                }
            }
            return min;
        }
        else
        {
            throw new ArgumentException("Empty IEnumerable");
        }
    }
    public static T MaxExt<T>(this IEnumerable<T> collection)
    where T : IComparable<T>
    {
        if (collection.Count() > 0)
        {
            IEnumerator<T> en = collection.GetEnumerator();
            en.MoveNext();
            T max = en.Current;
            while (en.MoveNext())
            {
                if (en.Current.CompareTo(max) > 0)
                {
                    max = en.Current;
                }
            }
            return max;
        }
        else
        {
            throw new ArgumentException("Empty IEnumerable");
        }
    }


    static void Main()
    {
        long[] array = { 3, 6, 8, 3 };
        Func<long, long, long> add = (a, b) => a + b;
        Console.WriteLine("Sum of array is:{0}",array.Sum(add));
        Func<long, long, long> product = (a, b) => a * b;
        Console.WriteLine("Product of array is:{0}", array.Product(product));
        Func<long, int, long> divide = (a, b) => a / b;
        Console.WriteLine("Average of array is:{0}", array.Average(add, divide));
        Console.WriteLine("Min value is {0}", array.MinExt());
        Console.WriteLine("Max value is {0}", array.MaxExt());
    }
}
