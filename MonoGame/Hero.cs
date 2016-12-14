using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGame
{
    class Hero : Sprite
    {
        public Vector2 Movement { get; set; }



        public Hero(Texture2D texture, Vector2 position, SpriteBatch batch)
            : base(texture, position, batch)
        {

        }

        public void Update(GameTime gameTime)
        {
            CheckKeyboardAndUpdateMovement();
            SimulateFriction();
            UpdatePositionBasedOnMovement(gameTime);
            
            
        }

        private void UpdatePositionBasedOnMovement(GameTime gameTime)
        {
            Position += Movement * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 15;
        }

        private void SimulateFriction()
        {
            Movement -= Movement * new Vector2(.2f, .2f);
        }

        private void CheckKeyboardAndUpdateMovement()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            if (keyboardState.IsKeyDown(Keys.Left)) { Movement += new Vector2(-1, 0); }
            if (keyboardState.IsKeyDown(Keys.Right)) { Movement += new Vector2(1, 0); }
            if (keyboardState.IsKeyDown(Keys.Up)) { Movement += new Vector2(0, -1); }
            if (keyboardState.IsKeyDown(Keys.Down)) { Movement += new Vector2(0, 1); }

        }
    }
}
