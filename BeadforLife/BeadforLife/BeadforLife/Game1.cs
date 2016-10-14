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

namespace BeadforLife
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState keys;

        Rectangle recBackground1;
        Rectangle recBackground2;
        Rectangle recHands1;
        Rectangle recHands2;
        Rectangle recRolls1;
        Rectangle recRolls2;

        int scoreOne;
        int scoreTwo;

        Texture2D picBackground;
        Texture2D picHands;
        Texture2D picRollOne;
        Texture2D picRollTwo;
        Texture2D picRollThree;
        Texture2D picRollFour;
        Texture2D picRollFive;
        Texture2D picRollSix;
        Texture2D picRollSeven;
        Texture2D picRollEight;
        Texture2D picRollNine;
        Texture2D picRollTen;

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
            keys = Keyboard.GetState();

            recBackground1 = new Rectangle(0, 0, 400, 480);
            recBackground2 = new Rectangle(400, 0, 400, 480);
            recHands1 = new Rectangle(300, 240, 100, 100);
            recHands2 = new Rectangle(500, 240, 100, 100);

            recRolls1 = new Rectangle(250, 220, 130, 120);
            recRolls2 = new Rectangle(450, 220, 130, 120);
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

            picBackground = Content.Load<Texture2D>("background");
            picHands = Content.Load<Texture2D>("hands");
            picRollOne = Content.Load<Texture2D>("roll1");
            picRollTwo = Content.Load<Texture2D>("roll2");
            picRollThree = Content.Load<Texture2D>("roll3");
            picRollFour = Content.Load<Texture2D>("roll4");
            picRollFive = Content.Load<Texture2D>("roll5");
            picRollSix = Content.Load<Texture2D>("roll6");
            picRollSeven = Content.Load<Texture2D>("roll7");
            picRollEight = Content.Load<Texture2D>("roll8");
            picRollNine = Content.Load<Texture2D>("roll9");
            picRollTen = Content.Load<Texture2D>("roll10");

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

            keys = Keyboard.GetState();
            KeyboardState oldpad1;
            if(keys.IsKeyDown(

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
            spriteBatch.Draw(picBackground, recBackground1, Color.White);
            spriteBatch.Draw(picBackground, recBackground2, Color.White);
            spriteBatch.Draw(picHands, recHands1, Color.White);
            spriteBatch.Draw(picHands, recHands2, Color.White);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
