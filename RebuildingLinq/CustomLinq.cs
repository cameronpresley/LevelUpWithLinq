using System;
using System.Collections.Generic;
using System.Linq;

namespace RebuildingLinq
{
  public static class IEnumerableExtensions
  {
    public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
      foreach (TSource item in source)
        yield return selector(item);
    }

    public static IEnumerable<T> Keep<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
      foreach (T item in source)
        if (predicate(item))
          yield return item;
    }

    public static TResult Reduce<T, TResult>(this IEnumerable<T> source, TResult seed, Func<TResult, T, TResult> reducer)
    {
      TResult current = seed;
      foreach(T item in source)
      {
        current = reducer(current, item);
      }
      return current;
    }

    public static bool Some<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
      foreach (T item in source)
      {
        if (predicate(item))
          return true;
      }
      return false;
    }

    public static bool Every<T> (this IEnumerable<T> source, Func<T, bool> predicate)
    {
      foreach (T item in source)
      {
        if (!predicate(item))
          return false;
      }
      return true;
    }

    public static T FirstOrDefault<T>(this IEnumerable<T> source)
    {
      foreach (T item in source)
      {
        return item;
      }
      return default(T);
    }

    public static T SingleOrDefault<T>(this IEnumerable<T> source)
    {
      bool hasSeenOne = false;
      T value = default(T);
      foreach (T item in source)
      {
        if (!hasSeenOne)
        {
          value = item;
          hasSeenOne = true;
        }
        else{
          throw new InvalidOperationException();
        }
      }
      return value;
    }

    public static IEnumerable<TResult> MapViaReduce<T, TResult> (this IEnumerable<T> source, Func<T, TResult> selector)
    {
      Func<IEnumerable<TResult>, T, IEnumerable<TResult>> reducer =
      (values, item) =>
      {
        TResult convertedItem = selector(item);
        return values.Append(convertedItem);
      };
      return source.Reduce(Enumerable.Empty<TResult>(), reducer);
    }

    public static IEnumerable<T> KeepViaReduce<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
      Func<IEnumerable<T>, T, IEnumerable<T>> reducer =
      (values, item) =>
      {
        if (predicate(item))
          return values.Append(item);
        else
          return values;
      };

      return source.Reduce(Enumerable.Empty<T>(), reducer);
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
    {
      foreach (T a in source)
        yield return a;
      yield return item;
    }
  }
}