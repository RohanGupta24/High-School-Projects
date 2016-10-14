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

namespace MovingWithSpeed_Lab
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        MedicineBottle[] bottles;

        Rectangle recHospital;
        Rectangle recAmbulance;
        Rectangle recHealth;

        Texture2D show;

        int speed = 25;

        Texture2D picBack;
        Texture2D picFront;
        Texture2D picLeft;
        Texture2D picRight;
        Texture2D picHospital;
        Texture2D healthBar;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            bottles = new MedicineBottle[2];
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
            recHospital = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            recAmbulance = new Rectangle(125, 160, 45, 30);
            recHealth = new Rectangle(GraphicsDevice.Viewport.Width - 245, GraphicsDevice.Viewport.Height - 300, 5, 7); //health bar rectangle

            bottles[0] = new MedicineBottle(new Rectangle(123, 87, 22, 23), false, Content.Load<Texture2D>("Medicine Bottle"));
            bottles[1] = new MedicineBottle(new Rectangle(321, 174, 19, 18), false, Content.Load<Texture2D>("Medicine Bottle")); 

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

            picBack = Content.Load<Texture2D>("AmbulanceBackward");
            picFront = Content.Load<Texture2D>("AmbulanceForward");
            picLeft = Content.Load<Texture2D>("AmbulanceLeft");
            picRight = Content.Load<Texture2D>("AmbulanceRight");
            picHospital = Content.Load<Texture2D>("Hospital Parking Lot");
            healthBar = Content.Load<Texture2D>("Health Bar");

            show = picFront;

            

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
            {
                recAmbulance.X = 125;
                recAmbulance.Y = 160;
            }

            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                show = picLeft;  
            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                show = picRight;
            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                show = picFront;
            if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                show = picBack;

            if ((show == picLeft) && (GamePad.GetState(PlayerIndex.One).Triggers.Right > 0))
                recAmbulance.X -= (int)(GamePad.GetState(PlayerIndex.One).Triggers.Right * speed);
            if ((show == picRight) && (GamePad.GetState(PlayerIndex.One).Triggers.Right > 0))
                recAmbulance.X += (int)(GamePad.GetState(PlayerIndex.One).Triggers.Right * speed);
            if ((show == picFront) && (GamePad.GetState(PlayerIndex.One).Triggers.Right > 0))
                recAmbulance.Y -= (int)(GamePad.GetState(PlayerIndex.One).Triggers.Right * speed);
            if ((show == picBack) && (GamePad.GetState(PlayerIndex.One).Triggers.Right > 0))
                recAmbulance.Y += (int)(GamePad.GetState(PlayerIndex.One).Triggers.Right * speed);
            for (int i = 0; i < bottles.Length; i++)
            {
                if (recAmbulance.Intersects(bottles[i].size))
                {
                    if (bottles[i].disappear == false)
                        recHealth.Width += 30;
                    bottles[i].disappear = true;
                }
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
            if (disappearOne == false && disappearTwo == false && disappearThree == false)
            {
                spriteBatch.Draw(picHospital, recHospital, Color.White);
                spriteBatch.Draw(show, recAmbulance, Color.White);
                spriteBatch.Draw(healthBar, recHealth, Color.White);
                spriteBatch.Draw(medicineBottle, recMed1, Color.White);
                spriteBatch.Draw(medicineBottle, recMed2, Color.White);
                spriteBatch.Draw(medicineBottle, recMed3, Color.White);
            }
            if (disappearOne)
            {
                spriteBatch.Draw(picHospital, recHospital, Color.White);
                spriteBatch.Draw(show, recAmbulance, Color.White);
                spriteBatch.Draw(healthBar, recHealth, Color.White);
                spriteBatch.Draw(medicineBottle, recMed2, Color.White);
                spriteBatch.Draw(medicineBottle, recMed3, Color.White);
            }
            if (disappearTwo)
            {
                spriteBatch.Draw(picHospital, recHospital, Color.White);
                spriteBatch.Draw(show, recAmbulance, Color.White);
                spriteBatch.Draw(healthBar, recHealth, Color.White);
                spriteBatch.Draw(medicineBottle, recMed1, Color.White);
                spriteBatch.Draw(medicineBottle, recMed3, Color.White);
            }
            if (disappearThree)
            {
                spriteBatch.Draw(picHospital, recHospital, Color.White);
                spriteBatch.Draw(show, recAmbulance, Color.White);
                spriteBatch.Draw(healthBar, recHealth, Color.White);
                spriteBatch.Draw(medicineBottle, recMed1, Color.White);
                spriteBatch.Draw(medicineBottle, recMed2, Color.White);
            }
            if (disappearOne && disappearTwo)
            {
                spriteBatch.Draw(picHospital, recHospital, Color.White);
                spriteBatch.Draw(show, recAmbulance, Color.White);
                spriteBatch.Draw(healthBar, recHealth, Color.White);
                spriteBatch.Draw(medicineBottle, recMed3, Color.White);
            }
            if (disappearOne && disappearThree)
            {
                spriteBatch.Draw(picHospital, recHospital, Color.White);
                spriteBatch.Draw(show, recAmbulance, Color.White);
                spriteBatch.Draw(healthBar, recHealth, Color.White);
                spriteBatch.Draw(medicineBottle, recMed2, Color.White);
            }
            if (disappearTwo && disappearThree)
            {
                spriteBatch.Draw(picHospital, recHospital, Color.White);
                spriteBatch.Draw(show, recAmbulance, Color.White);
                spriteBatch.Draw(healthBar, recHealth, Color.White);
                spriteBatch.Draw(medicineBottle, recMed1, Color.White);
            }
            if (disappearOne && disappearTwo && disappearThree)
            {
                spriteBatch.Draw(picHospital, recHospital, Color.White);
                spriteBatch.Draw(show, recAmbulance, Color.White);
                spriteBatch.Draw(healthBar, recHealth, Color.White);
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
