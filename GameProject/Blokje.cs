using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Blokje
    {
        private Texture2D Texture { get; set; }
        public Vector2 Positie { get; set; }
        public Rectangle collisionRectangle { get; set; }


        public Blokje(Texture2D _texture, Vector2 _positie)
        {
            Texture = _texture;
            Positie = _positie;
            collisionRectangle = new Rectangle(Convert.ToInt32(Positie.X), Convert.ToInt32(Positie.Y), 200, 200);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Positie, Color.White);
        }


    }
}
