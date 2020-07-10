using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RebuildingLinq
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("String Extension Methods");
      Console.WriteLine("h".Capitalize());
      Console.WriteLine("hello".Capitalize());
      Console.WriteLine("crazycase".CrazyCase());

      Console.WriteLine("Printing even numbers between 2 and 6 inclusive");
      new List<int> { 1, 2, 3, 4, 5 }
      .MapViaReduce(x => x + 1)
      .Keep(x => x % 2 == 0)
      .ToList()
      .ForEach(Console.WriteLine);

      Console.WriteLine("Printing even numbers between 2 and 6 inclusive with LINQ");
      Enumerable.Range(1, 5)
      .Select(x => x + 1)
      .Where(x => x % 2 == 0)
      .ToList()
      .ForEach(Console.WriteLine);

      Console.WriteLine("Summing numbers between 1 and 100 with Reduce");
      Console.WriteLine(Enumerable.Range(1, 100).Reduce(0, (a, b) => a + b));

      Console.WriteLine("Summing numbers between 1 and 100 with Aggregate");
      Console.WriteLine(Enumerable.Range(1, 100).Aggregate(0, (a, b) => a + b));

      var teams = new List<DeliveryTeam>
      {
        new DeliveryTeam {Name="AlphaTeam", TeamLead="Alice", MemberCount=5},
        new DeliveryTeam{Name="BackToTheCode", TeamLead="Bob", MemberCount=7},
        new DeliveryTeam {Name="SkillOverflowException", TeamLead="Cameron", MemberCount=10},
        new DeliveryTeam{Name="GittingThingsDone", TeamLead="Dana", MemberCount=8},
      };

      Func<DeliveryTeam, bool> moreThanSeven = t => t.MemberCount > 7;
      Func<DeliveryTeam, string> getName = t => t.Name;

      Console.WriteLine("Printing team names that have more than 7 members");
      teams
      .Where(moreThanSeven)
      .Select(getName)
      .ToList()
      .ForEach(Console.WriteLine);

      Console.WriteLine("Printing total number of team mates");
      Console.WriteLine(teams.Aggregate(0, (total, team) => total + team.MemberCount));

      Console.WriteLine("Press any key to exit");
      Console.ReadKey();
      
    }
  }
}
