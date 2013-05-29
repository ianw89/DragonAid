using System.Collections.Generic;
using System.Linq;

namespace DragonAid.Lib.Data
{
    public static class FatigueAndEncumberanceChart
    {
        private static readonly Dictionary<int, int[]> ColumnWeightLimitsByPhysicalStrengths;
        private static readonly FatigueAndEncumberanceChartEntry[] EntriesByColumn;

        static FatigueAndEncumberanceChart()
        {
            ColumnWeightLimitsByPhysicalStrengths = new Dictionary<int, int[]>
                {
                    { 3,  new[] {  0,  0,  0, 10, 18, 25, 35,  40,  50  }},
                    { 6,  new[] {  0,  0, 10, 15, 20, 30, 50,  60,  75  }},
                    { 12, new[] {  0, 10, 15, 20, 30, 50, 70,  80, 100 }},
                    { 17, new[] { 10, 15, 20, 30, 50, 70, 90, 100, 125 }},
                };
            EntriesByColumn = new[]
                {
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = 0 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -1 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -2 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -3 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -5 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -7 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -9 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -10 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -12 },
                };
        }

        public static FatigueAndEncumberanceChartEntry Lookup(int physicalStrength, decimal totalWeight)
        {
            // determine which row of the chart to use.
            var normalizedStrength = ColumnWeightLimitsByPhysicalStrengths.Keys.OrderBy(k => k).First(k => physicalStrength <= k);
            var rowValues = ColumnWeightLimitsByPhysicalStrengths[normalizedStrength];
            int column = 0;
            while (column < rowValues.Length - 1 && rowValues[column] <= totalWeight)
            {
                column++;
            }

            return EntriesByColumn[column];
        }
    }
}