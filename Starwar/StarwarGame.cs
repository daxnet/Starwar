using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Starwar
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Sprites;

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class StarwarGame : Game
    {
        private const string SpaceshipContentName = "spaceship";
        private const string LaserContentName = "laser";
        private const string MessageFontContentName = "message";
        private const string Enemy4ContentName = "enemy4";
        private const string ExplosionsContentName = "explosions";
        private const string BackgroundContentName = "background";
        private const string ParallaxStarContentName = "stars";
        private const string BgmContentName = "bgm";
        private const string ExplosionSoundContentName = "explosionSound";
        private const string LaserSoundContentName = "laserSound";
        private const string GameOverSoundContentName = "gameOver";

        private const int ParallaxStarCropLength = 32;

        private readonly GraphicsDeviceManager graphics;
        private readonly FrameCounter frameCounter = new FrameCounter();
        private readonly SpritePool<LaserSprite> laserPool;
        private readonly SpritePool<EnemySprite> enemyPool;
        private readonly SpritePool<AnimatedSprite> explosionPool;
        private readonly SpritePool<ParallaxStarSprite> starPool;
        private SpriteGenerator<EnemySprite> enemyGenerator;
        private SpriteGenerator<ParallaxStarSprite> starGenerator;
        
        // texture and content
        private SpriteFont messageFont;
        private Texture2D spaceshipTexture;
        private Texture2D laserTexture;
        private Texture2D enemy4Texture;
        private Texture2D explosionTexture;
        private Texture2D backgroundTexture;
        private Texture2D starTexture;
        private SoundEffect bgmEffect;
        private SoundEffect explosionSoundEffect;
        private SoundEffect laserSoundEffect;
        private SoundEffect gameOverSoundEffect;

        private SoundEffectInstance laserSound;
        private SoundEffectInstance explosionSound;
        private SoundEffectInstance gameOverSound;

        private readonly TimeSpan gameOverTimeSpan = TimeSpan.FromSeconds(3);
        private TimeSpan gameOverTimeCounter = TimeSpan.Zero;

        private bool gameOver = false;
        private bool gameOverSoundPlayed = false;

        // sprites
        private SpriteBatch spriteBatch;
        private SpaceshipSprite spaceshipSprite;
        private BackgroundSprite backgroundSprite;
        
        public StarwarGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            laserPool = new SpritePool<LaserSprite>(graphics);
            enemyPool = new SpritePool<EnemySprite>(graphics);
            explosionPool = new SpritePool<AnimatedSprite>(graphics);
            starPool = new SpritePool<ParallaxStarSprite>(graphics);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            base.Initialize();
            Window.AllowUserResizing = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load texture and contents
            messageFont = this.Content.Load<SpriteFont>(MessageFontContentName);
            laserTexture = this.Content.Load<Texture2D>(LaserContentName);
            spaceshipTexture = this.Content.Load<Texture2D>(SpaceshipContentName);
            enemy4Texture = this.Content.Load<Texture2D>(Enemy4ContentName);
            explosionTexture = this.Content.Load<Texture2D>(ExplosionsContentName);
            backgroundTexture = this.Content.Load<Texture2D>(BackgroundContentName);
            starTexture = this.Content.Load<Texture2D>(ParallaxStarContentName);
            bgmEffect = this.Content.Load<SoundEffect>(BgmContentName);
            explosionSoundEffect = this.Content.Load<SoundEffect>(ExplosionSoundContentName);
            explosionSound = explosionSoundEffect.CreateInstance();
            explosionSound.Volume = 1.0F;
            
            laserSoundEffect = this.Content.Load<SoundEffect>(LaserSoundContentName);
            laserSound = laserSoundEffect.CreateInstance();
            laserSound.Volume = 1.0F;

            gameOverSoundEffect = this.Content.Load<SoundEffect>(GameOverSoundContentName);
            gameOverSound = gameOverSoundEffect.CreateInstance();
            gameOverSound.Volume = 1.0F;
            //laserSound = laserSoundEffect.CreateInstance();
            //laserSound.Volume = 0.8F;

            // create sprites
            spaceshipSprite = new SpaceshipSprite(spaceshipTexture);
            backgroundSprite = new BackgroundSprite(backgroundTexture, graphics);
            //explosionSprite = new AnimatedSprite(this.explosionTexture, new Vector2(100, 100),
            //    new SpriteSheet(64, 64, 16, 0, 0), TimeSpan.FromMilliseconds(5));

            // create sprite generators
            enemyGenerator =
                new SpriteGenerator<EnemySprite>(
                    () =>
                        new EnemySprite(enemy4Texture,
                            new Vector2(Utils.GetRandomNumber(1, GraphicsDevice.Viewport.Width - enemy4Texture.Width), 1),
                            Utils.GetRandomNumber(5, 10)), enemyPool, TimeSpan.FromMilliseconds(900));

            starGenerator =
                new SpriteGenerator<ParallaxStarSprite>(() => new ParallaxStarSprite(starTexture, new Vector2(
                    Utils.GetRandomNumber(1,
                        GraphicsDevice.Viewport.Width - starTexture.Width), 1), Utils.GetRandomNumber(5, 20)), starPool,
                    TimeSpan.FromMilliseconds(100));

            var bgm = bgmEffect.CreateInstance();
            bgm.IsLooped = true;
            bgm.Play();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void EndRun()
        {
            base.EndRun();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.backgroundSprite.Update(gameTime);

            if (spaceshipSprite.IsActive)
            {
                var mouseState = Mouse.GetState();

                spaceshipSprite.X = mouseState.X - spaceshipSprite.Width/2;
                spaceshipSprite.Y = mouseState.Y - spaceshipSprite.Height/2;

                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    var laserSprite = new LaserSprite(laserTexture,
                        new Vector2(spaceshipSprite.X + (spaceshipSprite.Width - laserTexture.Width)/2.0F,
                            spaceshipSprite.Y));
                    PlaySound(laserSoundEffect, laserSound);
                    this.laserPool.Add(laserSprite);
                }

                foreach (var enemy in this.enemyPool.Sprites)
                {
                    foreach (var laser in this.laserPool.Sprites)
                    {
                        if (laser.CollidesWith(enemy))
                        {
                            PlaySound(explosionSoundEffect, explosionSound);
                            laser.IsActive = false;
                            enemy.IsActive = false;
                            var explosionSprite = new AnimatedSprite(explosionTexture, new Vector2(enemy.X, enemy.Y),
                                new SpriteSheet(64, 64, 16, 0, 0), TimeSpan.FromMilliseconds(5), 1);
                            this.explosionPool.Add(explosionSprite);
                        }
                    }

                    //if (enemy.CollidesWith(spaceshipSprite))
                    //{
                    //    PlaySound(explosionSoundEffect, explosionSound);
                    //    enemy.IsActive = false;
                    //    spaceshipSprite.IsActive = false;
                    //    var explosionSprite = new AnimatedSprite(explosionTexture, new Vector2(spaceshipSprite.X, spaceshipSprite.Y),
                    //            new SpriteSheet(64, 64, 16, 0, 0), TimeSpan.FromMilliseconds(5), 1);
                    //    this.explosionPool.Add(explosionSprite);
                    //}
                }
            }

            if (!spaceshipSprite.IsActive)
            {
                gameOverTimeCounter += gameTime.ElapsedGameTime;
                if (gameOverTimeCounter >= gameOverTimeSpan)
                {
                    gameOver = true;
                }
            }

            if (gameOver)
            {
                if (explosionSound != null && !explosionSound.IsDisposed)
                {
                    explosionSound.Stop(true);
                    explosionSound.Dispose();
                }
                if (laserSound != null && !laserSound.IsDisposed)
                {
                    laserSound.Stop(true);
                    laserSound.Dispose();
                }
                bgmEffect.Dispose();
                if (gameOverSound.State != SoundState.Playing && !gameOverSoundPlayed)
                {
                    gameOverSound.Play();
                    gameOverSoundPlayed = true;
                }
            }
            else
            {
                this.starGenerator.Update(gameTime);
                this.enemyGenerator.Update(gameTime);
                this.laserPool.Update(gameTime);
                this.explosionPool.Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            frameCounter.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            var fps = string.Format("FPS: {0}", frameCounter.AverageFramesPerSecond);

            spriteBatch.Begin();

            //this.explosionSprite.Draw(gameTime, spriteBatch);
            backgroundSprite.Draw(gameTime, spriteBatch);
            starGenerator.Draw(gameTime, spriteBatch);
            if (spaceshipSprite.IsActive)
            {
                spaceshipSprite.Draw(gameTime, spriteBatch);
            }

            enemyGenerator.Draw(gameTime, spriteBatch);

            
            laserPool.Draw(gameTime, spriteBatch);

            explosionPool.Draw(gameTime, spriteBatch);

            #region Output Debug Information
#if DEBUG
            // FPS
            spriteBatch.DrawString(messageFont, fps, Vector2.One, Color.Yellow);

            // Spacecraft Information
            var spaceCraftInfo = string.Format("[Spacecraft] X = {0}, Y = {1}", spaceshipSprite.X, spaceshipSprite.Y);
            spriteBatch.DrawString(messageFont, spaceCraftInfo, new Vector2(1, 15), Color.Yellow);

            // Laser Pool Information
            var laserPoolCountStr = string.Format("[Laser Pool] Count = {0}", this.laserPool.Count);
            spriteBatch.DrawString(messageFont, laserPoolCountStr, new Vector2(1, 30), Color.Yellow);

            // Enemy Pool Information
            var enemyPoolCountStr = string.Format("[Enemy Pool] Count = {0}", this.enemyPool.Count);
            spriteBatch.DrawString(messageFont, enemyPoolCountStr, new Vector2(1, 45), Color.Yellow);

            // Explosion Pool Information
            var explPoolCountStr = string.Format("[Expln Pool] Count = {0}", this.explosionPool.Count);
            spriteBatch.DrawString(messageFont, explPoolCountStr, new Vector2(1, 60), Color.Yellow);

            // Viewport Information
            var viewportInfoStr = string.Format("[ Viewport ] Width = {0}, Height = {1}", GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height);
            spriteBatch.DrawString(messageFont, viewportInfoStr, new Vector2(1, 75), Color.Yellow);

            // Game time Information
            var gameTimeInfoStr = string.Format("[ GameTime ] Total = {0}", gameTime.TotalGameTime);
            spriteBatch.DrawString(messageFont, gameTimeInfoStr, new Vector2(1, 90), Color.Yellow);
#endif
            #endregion

            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.spaceshipTexture.Dispose();
                this.laserTexture.Dispose();
                this.enemy4Texture.Dispose();
                this.explosionTexture.Dispose();
                this.backgroundTexture.Dispose();
                this.bgmEffect.Dispose();
                this.explosionSoundEffect.Dispose();
                this.laserSoundEffect.Dispose();
                this.gameOverSoundEffect.Dispose();

            }
            base.Dispose(disposing);
        }

        private void PlaySound(SoundEffect soundEffect, SoundEffectInstance soundEffectInstance, float volume = 1.0F)
        {
            if (soundEffectInstance != null &&
                !soundEffectInstance.IsDisposed)
            {
                soundEffectInstance.Dispose();
            }
            soundEffectInstance = soundEffect.CreateInstance();
            soundEffectInstance.Play();
        }
    }
}
