using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Character hero;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Disable default refresh rate of 59-60Hz
            // this.IsFixedTimeStep = false;
            // this.graphics.SynchronizeWithVerticalRetrace = false;

            // Set different refresh rate
            //this.IsFixedTimeStep = true;
            //this.graphics.SynchronizeWithVerticalRetrace = true;
            //this.TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 33); // 33ms = 30fps
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            hero = new Character(this.GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //texture = this.Content.Load<Texture2D>("charactersheet");

            // TODO: use this.Content to load your game content here
           
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Adding "pause" functionality
            if (IsActive)
            {
                // Exit the game if backspace on the gamepad or esc button on the keyboard have been pressed
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();

                // TODO: Add your update logic here
                // Adjust moving speed to 200px per second using variable timestep
                // position.X += 400.0f  * (float) gameTime.ElapsedGameTime.TotalSeconds;
                //position.X += 1;
                //if (position.X > this.GraphicsDevice.Viewport.Width - 100)
                //{
                //    position.X = 0;
                //}

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //spriteBatch.Begin();
            //spriteBatch.Draw(texture,
            //    destinationRectangle: new Rectangle(100 + 50, 100 + 50, 200, 200)
            //    //,
            //    // Rotate from the center of the texture
            //    // origin: new Vector2(texture.Width/2, texture.Height/2), 
            //    // Rotate
            //    // rotation: 45f
            //    // Tint
            //    // color: Color.Green
            //    // Flipped
            //    // effects: SpriteEffects.FlipHorizontally|SpriteEffects.FlipVertically
            //    );
            //spriteBatch.End();
            spriteBatch.Begin();
            hero.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Override functionality for activated/deactivated window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnActivated(object sender, EventArgs args)
        {
            this.Window.Title = "Game Running";
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            this.Window.Title = "Game Paused";
            base.OnDeactivated(sender, args);
        }
    }
}
