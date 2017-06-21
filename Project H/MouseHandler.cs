using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_H
{
	class MouseHandler
	{
		public MouseState mouseState;
		public MouseState oldMouseState;
		public int X;
		public int Y;
		public int TileX;
		public int TileY;
		public int currentSelectedTile;

		public MouseHandler()
		{
			currentSelectedTile=0;
		}

		public void Load()
		{

		}

		public void Update()
		{
			mouseState=Mouse.GetState();

			X=mouseState.X;
			Y=mouseState.Y;
			TileX=X/48;
			TileY=Y/48;

			if (Game1.editingMode)
			{
				if (mouseState.LeftButton==ButtonState.Pressed) //Holding down left mouse button.
				{
					Game1.PlaceTile(TileX,TileY,1);
				}

				if (mouseState.RightButton==ButtonState.Pressed) //Holding down left mouse button.
				{
					Game1.PlaceTile(TileX,TileY,0);
				}
			}


			oldMouseState=mouseState;
		}
	}
}
