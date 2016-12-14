using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGame
{
    class Character
    {
        // Using a static field allows us to share the same Texture2D across all CharacterEntity instances
        // This arrangement of multiple images in one file is referred to as a sprite sheet. Typically, a sprite will render only a portion of the sprite sheet. 
        static Texture2D characterSheetTexture;

        public float X { get; set; }
        public float Y { get; set; }

        public Character(GraphicsDevice graphicsDevice)
        {
            if (characterSheetTexture == null)
            {
          
                using (var stream = TitleContainer.OpenStream("Content/charactersheet.png"))
                {
                    characterSheetTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 topLeftOfSprite = new Vector2(this.X, this.Y);
            Color tintColor = Color.White;
            spriteBatch.Draw(characterSheetTexture, topLeftOfSprite, tintColor);
        }
    }
}
