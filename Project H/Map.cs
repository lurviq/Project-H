using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_H
{
    public class Map
    {
        public int[,] groundList;
        public int[,] maskList;
        public int[,] mask2List;
        public int[,] fringeList;
        public int[,] fringe2List;
        public int[,] blockedList;
        public int[,] specialList;

        public int searchX;
        public int searchY;
        public int tileSize = 48;
        public string name;

        private int width, height;

        public Map(string c_name, int c_width, int c_height)
        {
            name = c_name;
            width = c_width;
            height = c_height;
            groundList = new int[width, height]; //The array is the size of the map on X and Y size.
 
        }

        public void Load()
        {

        }

        public void Generate()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        spriteBatch.Draw(Game1.tileTextureList[groundList[x,y]], new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize), Color.White);
                    }
                }

            spriteBatch.DrawString(Game1.arial, name, new Vector2(((Game1.graphics.PreferredBackBufferWidth / 2) - Game1.arial.MeasureString(name).X), Game1.arial.LineSpacing), Color.White);
        }
        


    }
}
