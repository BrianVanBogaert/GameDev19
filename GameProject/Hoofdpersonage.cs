using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Hoofdpersonage
    {
        public Vector2 Positie;
        //public int ondergrens = 325;
        private Texture2D Texture { get; set; }
        public Rectangle collisionRectangle;
        public bool SpringEnable = false;
        public bool IsMoving = false;
        public float gravity = 50f;
        float jumspeed = 1200f;
        float movespeed = 400f;

        private Animation _animation;
        public Vector2 Velocity = new Vector2(0, 0);
        public Bediening _bediening { get; set; }
        SpriteEffects flipeffect = SpriteEffects.FlipHorizontally;

        public Hoofdpersonage(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;

            collisionRectangle = new Rectangle(Convert.ToInt32(Positie.X), Convert.ToInt32(Positie.Y), 332, 415);
            //_animation.CurrentFrame.SourceRectangle

            _animation = new Animation();
            _animation.AddFrame(new Rectangle(0, 0, 332, 415));
            _animation.AddFrame(new Rectangle(332, 0, 332, 415));
            _animation.AddFrame(new Rectangle(665, 0, 332, 415));
            _animation.AddFrame(new Rectangle(997, 0, 332, 415));
            _animation.AddFrame(new Rectangle(1330, 0, 332, 415));
            _animation.AddFrame(new Rectangle(1662, 0, 332, 415));
            _animation.AantalBewegingenPerSeconde = 15;


        }

        public void Update(GameTime gameTime, List<SoundEffect> geluidarray)
        {
            _bediening.Update();
            if (_bediening.left || _bediening.right)
            {
                _animation.Update(gameTime);
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }



            //=== We gaan naar rechts === 

            if (_bediening.right)
            {
                flipeffect = SpriteEffects.None;
                Velocity.X = movespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }


            //=== We gaan naar links === 

            else if (_bediening.left)
            {
                flipeffect = SpriteEffects.FlipHorizontally;
                Velocity.X = -movespeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            else
            {
                Velocity.X = 0;
            }

            //=== SPRINGEN === 

            if (_bediening.up && SpringEnable)
            {
                Velocity.Y = -jumspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                SpringEnable = false;
                // geluidarray[random.Next(2)].Play();
            }

            

            if (!SpringEnable)
            {
                Velocity.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                Velocity.Y = 0;
            }

            Positie += Velocity;

           // heeftGesprongen = Positie.Y >= ondergrens; //ondergrens
            collisionRectangle.X = Convert.ToInt16(Positie.X);
            collisionRectangle.Y = Convert.ToInt16(Positie.Y);
        }

        public void Draw(SpriteBatch spritebatch)
        {
           spritebatch.Draw(Texture, Positie, _animation.CurrentFrame.SourceRectangle, Color.White, 0, Vector2.One, 1f, flipeffect, 1);
          // spritebatch.Draw(Texture, Positie, collisionRectangle, Color.White, 0, Vector2.One, 1f, flipeffect, 1);
        }


        // ===================== NIEUWE COLLISION CODE =============================

        public void CollisionTest(Rectangle newRectangle, int xOffset, int yOffset)
        {
           

            if(collisionRectangle.TouchTopOf(newRectangle))
                {
                collisionRectangle.Y = newRectangle.Y - collisionRectangle.Height;
                Velocity.Y = 0f;
                SpringEnable = true;
                }
            else
            {
                SpringEnable = false;
                Velocity.Y = 1;
            }

          


            if (collisionRectangle.TouchLeftOf(newRectangle))
            {
                Positie.X = newRectangle.X - collisionRectangle.Width - 2;
            }

            if (collisionRectangle.TouchRightOf(newRectangle))
            {
                Positie.X = newRectangle.X + newRectangle.Width - 2;
            }

            if (collisionRectangle.TouchBottomOf(newRectangle))
            {
                Velocity.Y = 1f;
            }
      
        }

    }
}
