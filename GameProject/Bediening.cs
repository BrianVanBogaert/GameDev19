﻿using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public abstract class Bediening
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool up { get; set; }
        public abstract void Update();

    }

    public class BedieningPijltjes : Bediening
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Left))
            {
                left = true;
            }
            if (stateKey.IsKeyUp(Keys.Left))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(Keys.Right))
            {
                right = true;
            }
            if (stateKey.IsKeyUp(Keys.Right))
            {
                right = false;
            }

            if (stateKey.IsKeyDown(Keys.Up))
            {
                up = true;
            }
            if (stateKey.IsKeyUp(Keys.Up))
            {
                up = false;
            }
        }
    }
}
