using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace MonoGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        // Hero
        private Character hero;

        // Keyboard states used to determine key presses
        private KeyboardState currentKeyBoardState;
        private KeyboardState previousKeyBoardState;

        // Hero's movement speed
        private float heroMoveSpeed;

        // Tiles
        private Texture2D _tileTexture;
        private Sprite testSprite;
        private ArrayList tiles;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
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
            hero = new Character();
            hero.CharacterTexture = Content.Load<Texture2D>("hero");
            tiles = new ArrayList();
            heroMoveSpeed = 10.0f;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
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
            Vector2 heroPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            hero.Initialize(this.GraphicsDevice, heroPosition);
            _tileTexture = Content.Load<Texture2D>("blok");

            for (int i = 0; i < GraphicsDevice.Viewport.Width / 50; i++)
            {
                tiles.Add(new Sprite(_tileTexture, new Vector2(i * 50, GraphicsDevice.Viewport.TitleSafeArea.Height - 50), spriteBatch));
            }

            testSprite = new Sprite(_tileTexture, new Vector2(250, 250), spriteBatch);
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

                previousKeyBoardState = currentKeyBoardState;
                currentKeyBoardState = Keyboard.GetState();


                heroUpdate(gameTime);
                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen
            GraphicsDevice.Clear(Color.LightSkyBlue);

            // All of the drawing starts here
            spriteBatch.Begin();

            // Character rendering
            hero.Draw(spriteBatch);
            //testSprite.Draw();
            foreach (Sprite tile in tiles)
            {
                tile.Draw();
            }
            testSprite.Draw();

            // Render all sprites to the screen
            spriteBatch.End();
            
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

        private void heroUpdate(GameTime gameTime)
        {
            // Use the keyboard
            if (currentKeyBoardState.IsKeyDown(Keys.Left)) {
                hero.Position.X -= heroMoveSpeed;
            } else if (currentKeyBoardState.IsKeyDown(Keys.Right)) {
                hero.Position.X += heroMoveSpeed;
            } else if (currentKeyBoardState.IsKeyDown(Keys.Up))
            {
                hero.Position.Y -= heroMoveSpeed;
            } else if (currentKeyBoardState.IsKeyDown(Keys.Down))
            {
                hero.Position.Y += heroMoveSpeed;
            } else if (currentKeyBoardState.IsKeyDown(Keys.Space))
            {
                                
            }

            hero.Position.X = MathHelper.Clamp(hero.Position.X, 0, GraphicsDevice.Viewport.Width - hero.Width);
            hero.Position.Y = MathHelper.Clamp(hero.Position.Y, 0, GraphicsDevice.Viewport.Height - hero.Height);

        }
    }
}
