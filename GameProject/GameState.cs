using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
   
    public class GameState : State
    {
        Texture2D Hoofdpersonage_Texture;
        Hoofdpersonage hoofdpersonage;
        Camera2D camera;
        SoundEffect geluid;
        List<SoundEffect> geluidarray = new List<SoundEffect>();
        Level level1;
        public static int ScreenHeight;
        public static int ScreenWidth;
        ContentManager _content;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _content = content;
            LoadContent();
        }

        public override void LoadContent()
        {
            Hoofdpersonage_Texture = _content.Load<Texture2D>("boef");
            hoofdpersonage = new Hoofdpersonage(Hoofdpersonage_Texture, new Vector2(500, 0));
            hoofdpersonage._bediening = new BedieningPijltjes();
            level1 = new Level();
            level1.texture = _content.Load<Texture2D>("steenSmall");
            level1.BuildLVL();
            camera = new Camera2D();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: camera.Transform);
            _graphicsDevice.Clear(Color.CornflowerBlue);
            hoofdpersonage.Draw(spriteBatch);
            level1.DrawLVL(spriteBatch);
           
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            camera.Follow(hoofdpersonage);

            foreach (Blokje blok in level1.Blokjes)
                if (blok != null)
                {
                    hoofdpersonage.CollisionTest(blok.collisionRectangle, 0,0); //nieuwe collision test (stabieler)
                }

                    hoofdpersonage.Update(gameTime, geluidarray);
            //ColissionCheck();

           
        }


    

        //==========OUDE COLLISION CODE======= (gravity = ok , personage valt van een blok wanneer hij er van af loopt, side collsions zijn glitchy)
        //geen verantwoordelijkheid van gamestate => verhuist naar hoofdpersonage

        private void ColissionCheck()
        {
            bool onGround = false;
            bool botsLinks = false;
            bool botsRechts = false;

            foreach (Blokje blok in level1.Blokjes)
            {
                if (blok != null)
                {
                    if (hoofdpersonage.collisionRectangle.Intersects(blok.collisionRectangle))
                    {
                        // ================= LEFT CHECK N-OK =====================================

                        if ((hoofdpersonage.collisionRectangle.Left <= blok.collisionRectangle.Right) && (Keyboard.GetState().IsKeyDown(Keys.Left)))
                        {
                            botsLinks = true;
                            hoofdpersonage.Velocity.X = 0f;
                            hoofdpersonage.Positie = new Vector2(hoofdpersonage.Positie.X + 2, hoofdpersonage.Positie.Y);
                            System.Console.WriteLine("ben erin");
                        }



                        // ================= BOTTOM CHECK OK =====================================
                        if (hoofdpersonage.collisionRectangle.Bottom >= blok.collisionRectangle.Top)
                        {
                            hoofdpersonage.Velocity.Y = 0f;
                            hoofdpersonage.SpringEnable = false;
                            hoofdpersonage.Positie = new Vector2(hoofdpersonage.Positie.X, hoofdpersonage.Positie.Y);
                            hoofdpersonage.SpringEnable = true;
                            onGround = true;
                        }
                    }

                }
            }
            if (onGround == false)
            {
                hoofdpersonage.SpringEnable = false;
            }
        }

       






    }
}
