using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Camera2D
    {
        public Matrix Transform { get; private set; }
        public void Follow(Hoofdpersonage target)
        {
            Transform = Matrix.CreateTranslation((-target.Positie.X - target.collisionRectangle.Width / 2), //X
                                                (-target.Positie.Y - target.collisionRectangle.Height / 2), //Y
                                                0) * Matrix.CreateTranslation(
                                                    Game1.ScreenWidth / 2, 
                                                    Game1.ScreenHeight / 2, 
                                                    0);
        }
    }

}
