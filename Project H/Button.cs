using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_H
{
	class Button
	{
		public string graphicName;
		public Vector2 location;
		public Texture2D texture;
		ContentManager Content;

		public Button(string c_graphicName,int c_x,int c_y)
		{
			graphicName=c_graphicName;
			location=new Vector2(c_x,c_y);
		}

		public void LoadContent(ContentManager Content)
		{
			texture=Content.Load<Texture2D>("GUI/"+graphicName);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture,new Rectangle((int)location.X,(int)location.Y,48,48),Color.White);
			//spriteBatch.DrawString(Game1.arial, location.ToString(), location, Color.White);
		}
	}
}
