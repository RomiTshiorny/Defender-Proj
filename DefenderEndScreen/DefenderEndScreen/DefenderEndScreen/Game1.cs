using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DefenderEndScreen
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D gameOverBGTex, gameOverBGTex2, gameOverTextTex;

        Rectangle gameOverBGRect;
        Rectangle gameOverBGRect2, gameOverTextRect;

        int xv;


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
            xv = -3;
            gameOverBGRect = new Rectangle(0, 0, 1780, 480);
            gameOverBGRect2 = new Rectangle(1780, 0, 1780, 480);
            gameOverTextRect = new Rectangle(0, 0, 800, 480);
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
            gameOverBGTex = this.Content.Load<Texture2D>("gameOverBG");
            gameOverBGTex2 = this.Content.Load<Texture2D>("gameOverBG2");
            gameOverTextTex = this.Content.Load<Texture2D>("gameOverText");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            // TODO: Add your update logic here
            gameOverBGRect.X += xv;
            gameOverBGRect2.X += xv;
            if (gameOverBGRect2.X < 0)
                gameOverBGRect.X = gameOverBGRect2.X + gameOverBGRect.Width;
            if (gameOverBGRect.X < 0)
                gameOverBGRect2.X = gameOverBGRect.X + gameOverBGRect.Width;

            //if (gameOverBGRect2.X + gameOverBGRect2.Width < 800)
            //    gameOverBGRect2.X = gameOverBGRect2.X + gameOverBGRect2.Width;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(gameOverBGTex, gameOverBGRect, Color.White);
            spriteBatch.Draw(gameOverBGTex2, gameOverBGRect2, Color.White);
            spriteBatch.Draw(gameOverTextTex, gameOverTextRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
