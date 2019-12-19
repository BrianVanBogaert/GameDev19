using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Level
    {
        public Texture2D texture;
        //public BackGround BG;
        public byte[,] tileArray = new Byte[,]
       {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            { 1,1,1,1,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0 }

       };
        public Blokje[,] Blokjes;

        
        public Level()
        {
            Blokjes = new Blokje[tileArray.GetLength(0), tileArray.GetLength(1)];
            //BG = new BackGround(background);
        }

        public void BuildLVL()
        {
            for (int x = 0; x < Blokjes.GetLength(0); x++)
            {
                for (int y = 0; y < Blokjes.GetLength(1); y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        Blokjes[x, y] = new Blokje(texture, new Vector2(y * 200, x * 200)); //onze afbeelding is 200 breed en hoog
                    }

                }
            }
        }

        public void DrawLVL(SpriteBatch spritebatch)
        {
            for (int x = 0; x < Blokjes.GetLength(0); x++)
            {
                for (int y = 0; y < Blokjes.GetLength(1); y++)
                {
                    if (Blokjes[x, y] != null)
                    {
                        Blokjes[x, y].Draw(spritebatch);
                    }
                }
            }
        }
    }
}
