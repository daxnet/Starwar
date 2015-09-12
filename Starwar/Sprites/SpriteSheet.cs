using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starwar.Sprites
{
    internal struct SpriteSheet
    {

        public SpriteSheet(int frameWidth, int frameHeight, int frameCount, int offsetX, int offsetY)
            : this()
        {
            this.FrameWidth = frameWidth;
            this.FrameHeight = frameHeight;
            this.FrameCount = frameCount;
            this.OffsetX = offsetX;
            this.OffsetY = offsetY;
        }
        
        public int FrameWidth { get; set; }

        public int FrameHeight { get; set; }

        public int FrameCount { get; set; }

        public int OffsetX { get; set; }

        public int OffsetY { get; set; }
    }
}
