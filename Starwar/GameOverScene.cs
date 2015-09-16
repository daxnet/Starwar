using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starwar
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Graphics;

    internal sealed class GameOverScene : DisposableObject, IVisualElement
    {
        private const string GameOverSoundContentName = "gameOver";
        private const string GameOverFontContentName = "gameOverFont";
        private SoundEffect gameOverSoundEffect;
        private SoundEffectInstance gameOverSound;
        private readonly TimeSpan gameOverTimeSpan = TimeSpan.FromSeconds(3);
        private TimeSpan gameOverTimeCounter = TimeSpan.Zero;
        private SpriteFont gameOverFont;

        private readonly Game game;
        private readonly Func<bool> gameOverChecker;
        private bool gameOver = false;
        private bool gameOverSoundPlayed = false;
        private readonly Action gameOverCallback;

        internal GameOverScene(Game game, Func<bool> gameOverChecker, Action gameOverCallback)
        {
            this.game = game;
            this.gameOverChecker = gameOverChecker;
            this.gameOverCallback = gameOverCallback;
            gameOverFont = this.game.Content.Load<SpriteFont>(GameOverFontContentName);
            gameOverSoundEffect = this.game.Content.Load<SoundEffect>(GameOverSoundContentName);
            gameOverSound = gameOverSoundEffect.CreateInstance();
            gameOverSound.Volume = 1.0F;
            this.IsActive = false;
        }

        public bool IsActive { get; set; }

        public void Update(GameTime gameTime)
        {
            if (gameOverChecker() && this.IsActive)
            {
                gameOverTimeCounter += gameTime.ElapsedGameTime;
                if (gameOverTimeCounter >= gameOverTimeSpan)
                {
                    this.gameOver = true;
                }
            }

            if (this.gameOver)
            {
                gameOverCallback();
                if (gameOverSound.State != SoundState.Playing && !gameOverSoundPlayed)
                {
                    gameOverSound.Play();
                    gameOverSoundPlayed = true;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (gameOver)
            {
                var vector2 = gameOverFont.MeasureString("Game Over");
                var posx = (this.game.GraphicsDevice.Viewport.Width - vector2.X) / 2;
                var posy = (this.game.GraphicsDevice.Viewport.Height - vector2.Y) / 2;
                spriteBatch.DrawString(gameOverFont, "Game Over", new Vector2(posx, posy), Color.Red);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.gameOverSoundEffect.Dispose();
            }
        }
    }
}
