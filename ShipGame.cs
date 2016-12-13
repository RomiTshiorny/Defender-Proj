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

namespace Defender
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D shipText,bulletTex;
        //Rectangle shipRect;
        //int xV, yV;
        //bool pointsLeft, pointsRight, goingUp, getGoingDown;
        int timer;
        //int bulletTimer;
        Ship ship;
        KeyboardState oldKB;
        List<Bullet> bulletsFired = new List<Bullet>();
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
            //shipRect = new Rectangle(400, 240, 32, 16);
            //xV = 1;
            //yV = 1;
            //pointsLeft = true;
            //pointsRight = false;
            //goingUp = true;
            //getGoingDown = false;
            timer = 0;
            ship = new Ship(shipText, new Rectangle(400, 240, 32, 16));
            //bulletTimer = 0;
            oldKB = Keyboard.GetState();
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
            shipText = this.Content.Load<Texture2D>("ShipLeft");
            bulletTex = this.Content.Load<Texture2D>("bulletTex");
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
            KeyboardState kb = Keyboard.GetState();
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (kb.IsKeyDown(Keys.Down) && oldKB.IsKeyDown(Keys.Down) && ship.getShipRect().Y <= 480-16)
            {
                ship.moveDown();
                if (ship.getyV() < 3)
                    if (timer % 10 == 0)
                        ship.incrementyV();
            }
            if (kb.IsKeyDown(Keys.Up) && oldKB.IsKeyDown(Keys.Up)&&ship.getShipRect().Y>=0)
            {
                ship.moveUp();
                if (ship.getyV() < 3)
                    if (timer % 10 == 0)
                        ship.incrementyV();
            }
            if (kb.IsKeyDown(Keys.Left)&&oldKB.IsKeyDown(Keys.Left))
            {
                ship.moveLeft();
                if (ship.getxV() < 5)
                    if (timer % 10 == 0)
                        ship.incrementxV();
            }
            if (kb.IsKeyDown(Keys.Right)&& oldKB.IsKeyDown(Keys.Right))
            {
                ship.moveRight();
                if (ship.getxV() < 5)
                    if (timer % 10 == 0)
                        ship.incrementxV();
            }
            if (kb.IsKeyDown(Keys.Space)&&!oldKB.IsKeyDown(Keys.Space))
            {
                if(ship.getPointsLeft())
                    bulletsFired.Add(new Defender.Bullet(bulletTex, new Rectangle(ship.getShipRect().X, ship.getShipRect().Y+9, 3, 3),true));
                else
                    bulletsFired.Add(new Defender.Bullet(bulletTex, new Rectangle(ship.getShipRect().X+32, ship.getShipRect().Y + 9, 3, 3),false));
                ship.shoot();
            }
            for(int i = 0; i < bulletsFired.Count; i++)
            {
                if (bulletsFired[i].getGoingLeft())
                    bulletsFired[i].moveLeft();
                else
                    bulletsFired[i].moveRight();
            }
            if (ship.getPointsLeft())
                shipText = this.Content.Load<Texture2D>("ShipLeft");
            else
                shipText = this.Content.Load<Texture2D>("ShipRight");
            if (Keyboard.GetState().GetPressedKeys().Length<=0)
            {
                ship.onexV();
                ship.oneyV();
            }
            timer++;
            if (timer% 15 == 0)
                ship.incrementBulletTimer();

            oldKB = kb;
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
            spriteBatch.Draw(shipText, ship.getShipRect(), Color.White);
            for(int i=0;i<bulletsFired.Count;i++)
                spriteBatch.Draw(bulletsFired[i].getTex(), bulletsFired[i].getRect(), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
