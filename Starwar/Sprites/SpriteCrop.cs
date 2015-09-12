using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starwar.Sprites
{
    internal struct SpriteCrop
    {

        public SpriteCrop(int x, int y, int height, int width)
            :this()
        {
            this.X = x;
            this.Y = y;
            this.Height = height;
            this.Width = width;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }

        public int Width { get; set; }
    }
}
