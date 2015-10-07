using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace Starwar.ConfigTool
{
    internal sealed class BackgroundMusicItem
    {
        private static readonly BackgroundMusicItem[] all = {
            new BackgroundMusicItem
            {
                DisplayName = "沙罗曼蛇背景音乐Remix",
                SoundEffect = "bgm"
            },
            new BackgroundMusicItem
            {
                DisplayName = "双截龙2最终BOSS背景音乐Remix",
                SoundEffect = "FightOfFate"
            }
        };

        public string DisplayName { get; set; }

        public string SoundEffect { get; set; }

        public static IEnumerable<BackgroundMusicItem> All
        {
            get
            {
                return all;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return DisplayName;
        }
    }
}
