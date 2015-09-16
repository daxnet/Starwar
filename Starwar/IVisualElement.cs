namespace Starwar
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Represents that the implemented classes are game visual elements, which
    /// can update their game model and draw the textures on the game window.
    /// </summary>
    internal interface IVisualElement
    {
        /// <summary>
        /// Gets or sets a value indicating whether the current visual element is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if current visual element is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }

        /// <summary>
        /// Updates the game model according to the current game time.
        /// </summary>
        /// <param name="gameTime">The game time on which the game model is updating.</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Draws the textures on the game window according to the current game time.
        /// </summary>
        /// <param name="gameTime">The game time when the texture is drawn.</param>
        /// <param name="spriteBatch">The <see cref="SpriteBatch"/> instance used for drawing the texture.</param>
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
