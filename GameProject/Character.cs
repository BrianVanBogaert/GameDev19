using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Character
    {
        public Vector2 Position;

        private int Health;
        public int health
        {
            get
            {
                return Health;
            }
            set
            {
                Health = value;
            }
        }

        private Rectangle Hitbox;
        public Rectangle hitbox
        {
            get
            {
                return Hitbox;
            }
            set
            {
                Hitbox = value;
            }
        }


    }
}
