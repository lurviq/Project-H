using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_H
{
	class KeyboardHandler
	{
		public KeyboardState keyboardState;
		public KeyboardState oldKeyboardState;

		public bool keyPressed(Keys key)
		{
			return keyboardState.IsKeyDown(key)&&oldKeyboardState.IsKeyUp(key);
		}

		public bool keyReleased(Keys key)
		{
			return keyboardState.IsKeyUp(key)&&oldKeyboardState.IsKeyDown(key);
		}

		public bool keyDown(Keys key)
		{
			return keyboardState.IsKeyDown(key);
		}

		public bool keyUp(Keys key)
		{
			return keyboardState.IsKeyUp(key);
		}

		public bool canInput;

		public KeyboardHandler()
		{
			canInput=true;
		}

		public void Load()
		{

		}

		public void Update()
		{
			keyboardState=Keyboard.GetState();

			//if (keyboardState.IsKeyDown(Keys.Insert)&&oldKeyboardState.IsKeyUp(Keys.Insert))
			if (keyPressed(Keys.Insert))
			{
				if (Game1.editingMode)
				{
					Game1.editingMode=false;
					Game1.debugString="Not editing";
				}
				else
				{
					Game1.editingMode=true;
					Game1.debugString="Editing";
				}
			}

			oldKeyboardState=keyboardState;
		}
	}
}
