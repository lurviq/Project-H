using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_H
{
    public class Player
    {
        //Stats
        public int hp;
        public int maxHP;
        public int sp;
        public int maxSP;
        public int powerlevel;

        //Location
        public int map;
        public Vector2 position;
        public Vector2 motion;
        public Rectangle rectangle;
        
        

        //Personal info
        public string name;
        public int age = 18;

        //Graphical
        public int width, height;
        public string graphicName;
        public Texture2D texture;

        

        public Player(int c_hp, int c_maxHP, int c_sp, int c_maxSP, int c_powerlevel, int c_map, int c_x, int c_y, string c_name, string c_graphicName, int c_width, int c_height)
        {
            //Assigning stats
            hp = c_hp;
            maxHP = c_maxHP;
            sp = c_sp;
            maxSP = c_maxSP;
            powerlevel = c_powerlevel;
            //Assigning personal info
            name = c_name;
            //Location
            map = c_map;
            position = new Vector2(c_x, c_y);
            //Graphical
            graphicName = c_graphicName;
            width = c_width;
            height = c_height;
            rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Load(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("Entities/Player");

        }

        public void Update(GameTime gameTime)
        {
            
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public void CanMove(int direction, GameTime gameTime)
        {
            switch (direction)
            {
                case 0:
                    Move(0, gameTime, new Vector2(0, -5));
                    break;
                case 1:
                    Move(1, gameTime, new Vector2(5, 0));
                    break;
                case 2:
                    Move(2, gameTime, new Vector2(0, 5));
                    break;
                case 3:
                    Move(3, gameTime, new Vector2(-5, 0));
                    break;

            } 
        }

        public void Move(int direction, GameTime gameTime, Vector2 Motion)
        {
            if (Motion != Vector2.Zero)
            {
                Motion.Normalize();
                position.X += Motion.X * (int)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
                position.Y += Motion.Y * (int)gameTime.ElapsedGameTime.TotalMilliseconds / 4;
                if (position.X < 0)
                    position.X = 0;
                if (position.Y < 0)
                    position.Y = 0;
                if (position.X + texture.Width > Game1.graphics.PreferredBackBufferWidth)
                    position.X = Game1.graphics.PreferredBackBufferWidth - texture.Width;
                if (position.Y + texture.Height > Game1.graphics.PreferredBackBufferHeight)
                    position.Y = Game1.graphics.PreferredBackBufferHeight - texture.Height;
            }
        }





    }

}
