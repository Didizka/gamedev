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
        private Hero hero;
        private Texture2D heroTexture;

        // Keyboard states used to determine key presses
        private KeyboardState currentKeyBoardState;
        private KeyboardState previousKeyBoardState;
        

        // Tiles
        private Texture2D tileTexture;
        private Sprite testSprite;
        private ArrayList tiles;

        // Game Board
        private int columns;
        private int rows;
        private Board board;

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
            tiles = new ArrayList();
            rows = 10;
            columns = 15;
            graphics.PreferredBackBufferHeight = rows * 50;
            graphics.PreferredBackBufferWidth = columns * 50;
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
            tileTexture = Content.Load<Texture2D>("blok");

            for (int i = 0; i < GraphicsDevice.Viewport.Width / 50; i++)
            {
                tiles.Add(new Sprite(tileTexture, new Vector2(i * 50, GraphicsDevice.Viewport.TitleSafeArea.Height - 50), spriteBatch));
            }

            testSprite = new Sprite(tileTexture, new Vector2(250, 250), spriteBatch);
            board = new Board(spriteBatch, tileTexture, columns, rows);


            heroTexture = Content.Load<Texture2D>("hero");
            hero = new Hero(heroTexture, new Vector2(50, 50), spriteBatch);
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

                hero.Update(gameTime);
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


            //foreach (sprite tile in tiles)
            //{
            //    tile.draw();
            //}
            //testsprite.draw();
            board.Draw();


            // Character rendering
            hero.Draw();

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

        
    }
}
