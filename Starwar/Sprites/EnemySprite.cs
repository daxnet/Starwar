using System;
using NLua;

namespace Starwar.Sprites
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class EnemySprite : Sprite
    {
        private readonly float speed;
        private readonly Vector2 initPos;
        private readonly Lua state = new Lua();
        private readonly LuaFunction luaFunction;

        private const string Script = @"
    function CalculatePosition(initX, initY, x, y, speed)
        return initX + math.sin(y / 100.0) * 100, y + speed
        -- return x, y + speed
    end
";

        public EnemySprite(Texture2D texture, Vector2 position, float speed) : base(texture, position)
        {
            this.speed = speed;
            this.initPos = position;
            state.DoString(Script);
            luaFunction = state["CalculatePosition"] as LuaFunction;
        }

        public override void Update(GameTime gameTime)
        {

            // this.Y += speed;
            // var function = state["CalculatePosition"] as LuaFunction;
            var result = luaFunction.Call(this.initPos.X, this.initPos.Y, this.X, this.Y, speed);
            this.X = Convert.ToInt32(result[0]);
            this.Y = Convert.ToInt32(result[1]);
            base.Update(gameTime);
        }
    }
}
