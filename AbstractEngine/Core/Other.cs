﻿using AbstractEngine.Core.Base;

namespace AbstractEngine.Core
{
    public static class Other
    {
        public static int GetCenterStartPositionForText(string text, int WindowWidth, int offset)
            => (WindowWidth - offset - text.Length) / 2;
    }
}