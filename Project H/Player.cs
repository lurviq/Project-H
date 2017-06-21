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
	class Player
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
		public Rectangle rectangle;

		//Personal info
		public string name;
		public int age=18;

		//Graphical
		public int width,height;
		public string graphicName;
		public Texture2D texture;

		//Controls
		public KeyboardState keyboardState;

		public Player(int c_hp,int c_maxHP,int c_sp,int c_maxSP,int c_powerlevel,int c_map,int c_x,int c_y,string c_name,string c_graphicName,int c_width,int c_height)
		{
			//Assigning stats
			hp=c_hp;
			maxHP=c_maxHP;
			sp=c_sp;
			maxSP=c_maxSP;
			powerlevel=c_powerlevel;

			//Assigning personal info
			name=c_name;

			//Location
			map=c_map;
			position=new Vector2(c_x,c_y);

			//Graphical
			graphicName=c_graphicName;
			width=c_width;
			height=c_height;
		}

		public void Load(ContentManager Content)
		{
			texture=Content.Load<Texture2D>("Entities/Player");
		}

		public void Update(GameTime gameTime)
		{
			CanMove(gameTime);
			rectangle=new Rectangle((int)position.X,(int)position.Y,texture.Width,texture.Height);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture,rectangle,Color.White);
		}

		public void CanMove(GameTime gameTime)
		{
			keyboardState=Keyboard.GetState();

			if (keyboardState.IsKeyDown(Keys.Up))
			{
				Move(0,gameTime);
			}
			if (keyboardState.IsKeyDown(Keys.Right))
			{
				Move(1,gameTime);
			}
			if (keyboardState.IsKeyDown(Keys.Down))
			{
				Move(2,gameTime);
			}
			if (keyboardState.IsKeyDown(Keys.Left))
			{
				Move(3,gameTime);
			}
		}

		public void Move(int direction,GameTime gameTime)
		{
			switch (direction)
			{
				case 0:
					position.Y-=(float)gameTime.ElapsedGameTime.TotalMilliseconds/5;
					break;
				case 1:
					position.X+=(float)gameTime.ElapsedGameTime.TotalMilliseconds/5;
					break;
				case 2:
					position.Y+=(float)gameTime.ElapsedGameTime.TotalMilliseconds/5;
					break;
				case 3:
					position.X-=(float)gameTime.ElapsedGameTime.TotalMilliseconds/5;
					break;
			}
		}
	}
}
