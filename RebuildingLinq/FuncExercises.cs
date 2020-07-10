using System;
using System.Collections.Generic;
using System.Linq;

namespace RebuildingLinq
{
  // What's a Func?
  // It's a type that represents something that returns a value
  // Func<int> -> No inputs, returns an integer
  // Func<int, int> -> Takes one integer as input, returns an integer
  // Func<int, int, int> -> Takes two integers as input, returns an integer

  // Funcs can be defined a number of ways
  public class FuncExercises
  {
    public void DefiningFuncs()
    {
      // No input, returns an int
      Func<int> getNumber = () => 2;


      // Takes an int, returns a string
      Func<int, string> toString = x => x.ToString();
      
      
      // Takes an int and a string, returns a string
      Func<int, string, string> repeatString = 
        (num, s) => String.Join("",Enumerable.Range(1, num).Select(x=>s));

      Func<int, int> square = (x) => x * x;

      Func<List<int>, int> sum = (xs) =>
      {
        int total = 0;
        foreach (var x in xs)
        {
          total += x;
        }
        return total;
      };
    }


    private int Add(int a, int b)
    {
      return a + b;
    }
  }
}