using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class Character
    {
        // Animation representing the character
        public Texture2D CharacterTexture;

        // Position of the character
        public Vector2 Position;

        // State of the character
        public bool Active;

        // Amount of hit points of the character
        public int HP;

        // Size of the sprite
        public int Width;
        public int Height;




       public void Initialize(GraphicsDevice graphicsDevice, Vector2 position) {
            if (CharacterTexture == null)
            {

                using (var stream = TitleContainer.OpenStream("Content/hero.png"))
                {
                    CharacterTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }
            Position = position;
            Active = true;
            HP = 100;
            Width = 60;
            Height = 60;

        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(CharacterTexture, Position, new Rectangle(0, 0, this.Width, this.Height), Color.White);
        }

        public void Update()
        {

        }
    }
}
