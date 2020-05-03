using System;
using AbstractEngine.Core.Base;

namespace AbstractEngine.Core
{
    public static class Other
    {
        public static int GetCenterStartPositionForText(string text, int windowWidth)
            => (windowWidth - text.Length) / 2 ;

        public static Color RandomColor(params Color[] fromColors)
        {
            var r = new Random();
            return fromColors[r.Next(0, fromColors.Length)];
        }
    }
}