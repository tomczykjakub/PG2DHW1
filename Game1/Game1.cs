﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        private Texture2D texture,texture2;
        private Vector2 position,position2;
        private Rectangle textureGranica, texture2Granica;
        private string kolizja;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            texture = Content.Load<Texture2D>("Box");
            position = new Vector2(0, 0);
            texture2 = Content.Load<Texture2D>("Box");
            position2 = new Vector2(300, 300);
            font = Content.Load<SpriteFont>("font");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var keyboard = Keyboard.GetState();
            //ruch pierwszego
            if (keyboard.IsKeyDown(Keys.Up))
                position.Y = position.Y - 1;

            if (keyboard.IsKeyDown(Keys.Down))
                position.Y = position.Y + 1;

            if (keyboard.IsKeyDown(Keys.Left))
                position.X = position.X - 1;

            if (keyboard.IsKeyDown(Keys.Right))
                position.X = position.X + 1;
            //ruch drugiego
            if (keyboard.IsKeyDown(Keys.W))
                position2.Y = position2.Y - 1;

            if (keyboard.IsKeyDown(Keys.S))
                position2.Y = position2.Y + 1;

            if (keyboard.IsKeyDown(Keys.A))
                position2.X = position2.X - 1;

            if (keyboard.IsKeyDown(Keys.D))
                position2.X = position2.X + 1;

            textureGranica = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            texture2Granica = new Rectangle((int)position2.X, (int)position2.Y, texture2.Width, texture2.Height);
            if (texture2Granica.Intersects(textureGranica))
            {
                kolizja = "KOLIZJA";

            }
            else
            {
                kolizja = "BRAK KOLIZJI";

            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(font,kolizja,new Vector2(650,0),Color.Black);
            spriteBatch.Draw(texture,position,Color.White);
            spriteBatch.Draw(texture2, position2, Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
