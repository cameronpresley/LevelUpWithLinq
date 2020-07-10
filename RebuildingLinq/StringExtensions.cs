using System;

namespace RebuildingLinq
{
  public static class StringExtensions
  {
    public static string Capitalize(this string s)
    {
      if (String.IsNullOrWhiteSpace(s)) return s;
      return Char.ToUpper(s[0]) + s.Substring(1);
    }

    public static string CrazyCase(this string s)
    {
      if (string.IsNullOrWhiteSpace(s)) return s;
      var chars = s.ToCharArray();
      for (var i = 0; i < s.Length; i++)
      {
        chars[i] = i % 2 == 0 ? Char.ToUpper(chars[i]) : Char.ToLower(chars[i]);
      }
      return new String(chars);
    }
  }
}