using System;
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
                    {  3, new[] {  0,  0,  0, 10, 14, 18,  22,  25,  30,  35,  40,  45,  50 }},
                    {  4, new[] {  0,  0,  3, 11, 15, 19,  23,  26,  33,  39,  45,  50,  55 }},
                    {  5, new[] {  0,  0,  5, 13, 16, 19,  24,  28,  35,  43,  50,  55,  60 }},
                    {  6, new[] {  0,  0,  8, 14, 17, 20,  24,  29,  38,  46,  55,  60,  65 }},
                    {  7, new[] {  0,  0, 10, 15, 18, 20,  25,  30,  40,  50,  60,  65,  70 }},
                    {  8, new[] {  0,  3, 11, 16, 19, 23,  29,  35,  45,  55,  65,  71,  78 }},
                    {  9, new[] {  0,  5, 13, 18, 21, 25,  33,  40,  50,  60,  70,  78,  85 }},
                    { 10, new[] {  0,  8, 14, 19, 23, 28,  36,  45,  55,  65,  75,  84,  93 }},
                    { 11, new[] {  0, 10, 15, 20, 25, 30,  40,  50,  60,  70,  80,  90, 100 }},
                    { 12, new[] {  3, 11, 16, 23, 29, 35,  45,  55,  65,  75,  85,  95, 106 }},
                    { 13, new[] {  5, 13, 18, 25, 33, 40,  50,  60,  70,  80,  90, 100, 113 }},
                    { 14, new[] {  8, 14, 19, 28, 36, 45,  55,  65,  75,  85,  95, 105, 119 }},
                    { 15, new[] { 10, 15, 20, 30, 40, 50,  60,  70,  80,  90, 100, 110, 125 }},
                    { 16, new[] { 11, 16, 23, 33, 43, 53,  64,  75,  86,  98, 108, 118, 131 }},
                    { 17, new[] { 13, 18, 25, 35, 45, 55,  68,  80,  93, 105, 115, 125, 138 }},
                    { 18, new[] { 14, 19, 28, 38, 48, 58,  71,  85,  99, 113, 123, 133, 144 }},
                    { 19, new[] { 15, 20, 30, 40, 50, 60,  75,  90, 105, 120, 130, 140, 150 }},
                    { 20, new[] { 17, 23, 37, 47, 57, 67,  83, 100, 117, 133, 143, 155, 167 }},
                    { 21, new[] { 18, 27, 43, 53, 63, 73,  92, 110, 128, 147, 157, 170, 183 }},
                    { 22, new[] { 20, 30, 50, 60, 70, 80, 100, 120, 140, 160, 170, 185, 200 }},
                    { 23, new[] { 23, 33, 53, 63, 74, 85, 105, 125, 145, 165, 175, 190, 206 }},
                    { 24, new[] { 25, 35, 55, 65, 78, 90, 110, 130, 150, 170, 180, 195, 213 }},
                    { 25, new[] { 28, 38, 58, 68, 81, 95, 115, 135, 155, 175, 185, 200, 219 }},
                };
            EntriesByColumn = new[]
                {
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =   0 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -1 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -2 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -3 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -4 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -5 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -6 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -7 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -8 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier =  -9 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -10 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -12 },
                    new FatigueAndEncumberanceChartEntry { AgilityModifier = -12 },
                };
        }

        public static FatigueAndEncumberanceChartEntry Lookup(int physicalStrength, decimal totalWeight)
        {
            physicalStrength = Math.Max(3, Math.Min(physicalStrength, 25));

            // determine which row of the chart to use.
            int[] rowValues;
            if (!ColumnWeightLimitsByPhysicalStrengths.TryGetValue(physicalStrength, out rowValues))
            {
                // uhhh, throw i guess.
                throw new NotImplementedException();
            }

            int column = 0;
            while (column < rowValues.Length - 1 && rowValues[column] < totalWeight)
            {
                column++;
            }

            return EntriesByColumn[column];
        }
    }
}