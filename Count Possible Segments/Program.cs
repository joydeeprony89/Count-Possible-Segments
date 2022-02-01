using System;
using System.Collections.Generic;

namespace Count_Possible_Segments
{
  class Program
  {
    static void Main(string[] args)
    {
      List<int> weights = new List<int>() { 1, 3,  6 };
      Console.WriteLine(countPossibleSegments(3, weights));
    }

    public static long countPossibleSegments(int k, List<int> weights)
    {
      long count = 0;
      int n = weights.Count;
      for (int i = 0; i < n; i++)
      {
        int rangeCount = 0;
        for (int j = i; j < n; j++)
        {
          var list = weights.GetRange(i, ++rangeCount);
          var (largest, smallest) = FindLargestAndSmallest(list);
          var difference = largest - smallest;
          if (difference <= k) count++;
        }
      }

      return count;
    }

    static (int, int) FindLargestAndSmallest(List<int> list)
    {
      int largest = int.MinValue;
      int smallest = int.MaxValue;
      foreach(int n in list)
      {
        if (n > largest) largest = n;
        if (n < smallest) smallest = n;
      }

      //largest = largest == int.MinValue ? smallest : largest;
      //smallest = smallest == int.MaxValue ? largest : smallest;
      return (largest, smallest);
    }
  }
}
