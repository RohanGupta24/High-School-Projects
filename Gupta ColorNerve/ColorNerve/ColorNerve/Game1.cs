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
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Net;

namespace ColorNerve
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GamePadState pad1;
        GamePadState pad2;
        KeyboardState kb;

        byte redIntensity = 0;
        byte greenIntensity = 0;
        byte blueIntensity = 0;

        bool playerOneOut = false;
        bool playerTwoOut = false;

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
            /*
            pad1 = GamePad.GetState(PlayerIndex.One);
            pad2 = GamePad.GetState(PlayerIndex.Two);
            kb = Keyboard.GetState();

            redIntensity = 0;
            greenIntensity = 0;
            blueIntensity = 0;

            playerOneOut = false;
            playerTwoOut = false;
            */

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
            pad1 = GamePad.GetState(PlayerIndex.One);
            pad2 = GamePad.GetState(PlayerIndex.Two);
            kb = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed|| Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            if (kb.IsKeyDown(Keys.Q))
            {
                redIntensity++;
                if (redIntensity >= 255)
                    playerOneOut = true;
            }

            if (kb.IsKeyDown(Keys.W))
            {
                greenIntensity++;
                if (greenIntensity >= 255)
                    playerOneOut = true;
            }
            if (kb.IsKeyDown(Keys.E))
            {
                blueIntensity++;
                if (blueIntensity >= 255)
                    playerOneOut = true;
            }

            if (kb.IsKeyDown(Keys.I))
            {
                redIntensity++;
                if (redIntensity >= 255)
                    playerTwoOut = true;
            }
            if (kb.IsKeyDown(Keys.O))
            {
                greenIntensity++;
                if (greenIntensity >= 255)
                    playerTwoOut = true;
            }
            if (kb.IsKeyDown(Keys.P))
            {
                blueIntensity++;
                if (blueIntensity >= 255)
                    playerTwoOut = true;
            }

            if (pad1.Buttons.B == ButtonState.Pressed)
            {
                redIntensity++;
                if (redIntensity >= 255)
                    playerOneOut = true;
            }
            if (pad1.Buttons.A == ButtonState.Pressed)
            {
                greenIntensity++;
                if (greenIntensity >= 255)
                    playerOneOut = true;
            }
            if (pad1.Buttons.X == ButtonState.Pressed)
            {
                blueIntensity++;
                if (blueIntensity >= 255)
                    playerOneOut = true;
            }

            if (pad2.Buttons.B == ButtonState.Pressed)
            {
                redIntensity++;
                if (redIntensity >= 255)
                    playerTwoOut = true;
            }
            if (pad2.Buttons.A == ButtonState.Pressed)
            {
                greenIntensity++;
                if (greenIntensity >= 255)
                    playerTwoOut = true;
            }
            if (pad2.Buttons.X == ButtonState.Pressed)
            {
                blueIntensity++;
                if (blueIntensity >= 255)
                    playerTwoOut = true;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Color backgroundColor = new Color(redIntensity, greenIntensity, blueIntensity);
            
            if (playerOneOut)
            {
                GraphicsDevice.Clear(Color.White);
                GamePad.SetVibration(PlayerIndex.One, 0, 1);
            }
            else if (playerTwoOut)
            {
                GraphicsDevice.Clear(Color.Black);
                GamePad.SetVibration(PlayerIndex.Two, 0, 1);
            }
            else
            {
                GraphicsDevice.Clear(backgroundColor);
            }


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
