using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starwar.Common
{
    public sealed class Settings
    {
        public int NumOfEnemiesPerSecond { get; set; }
        public bool ShowDebugInfo { get; set; }
        public bool LiveForever { get; set; }

    }
}
