using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project_H
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        //My Objects
        Player player;
        static Map map;
        MouseHandler mouseHandler;
        KeyboardHandler keyboardHandler;
        //Graphics
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //Other
        public static List<Texture2D> tileTextureList;
        public static SpriteFont arial;
        Texture2D tileTexture;
        MouseState oldMouseState;
        MouseState mouseState = Mouse.GetState();
        public static string debugString = "N/A";
        public static string debugString2 = "N/A";
        public static string debugString3 = "N/A";
        public static bool editingMode;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            
            IsMouseVisible = true;

            map = new Map("Town", 30,30); //Set the current map to map 0.
            tileTextureList = new List<Texture2D>();
            player = new Player(100, 100, 100, 100, 1, 0, 90, 90, "Saisei", "Player", 48, 64);
            mouseHandler = new MouseHandler();
            keyboardHandler = new KeyboardHandler();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.Load(Content);
            
            for (int i = 0; i < Globals.MAX_TILES; i++)
            {
                try
                {
                    tileTexture = Content.Load<Texture2D>("Tiles/" + i);
                    tileTextureList.Add(tileTexture);
                   
                }
                catch (Microsoft.Xna.Framework.Content.ContentLoadException)
                {
                    break; //Break out of the for loop if there's no more tiles to load.
                }
            }



            player.texture = Content.Load<Texture2D>("Entities/" + player.graphicName);
            arial = Content.Load<SpriteFont>("Fonts/arial");
            
        }

        protected override void UnloadContent()
        {
        //Unload stuff here if we need to.
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            if (IsActive) //Check so we can't interact with the game if we're tabbed away.
            {
                mouseHandler.Update();
                keyboardHandler.Update();
                player.CheckMove(gameTime);
            }
            base.Update(gameTime);
        }

        public static void PlaceTile(int x, int y, int selectedTile)
        {
            map.groundList[x, y] = selectedTile;
        }

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();

            map.Draw(spriteBatch);


            //Draw each map tile for itself.

            //Player
            player.Draw(spriteBatch);
            
            //Debug
            spriteBatch.DrawString(arial, "MouseX: " + mouseHandler.X + "(" + mouseHandler.TileX + ")", new Vector2(0,0), Color.White);
            spriteBatch.DrawString(arial, "MouseY: " + mouseHandler.Y + "(" + mouseHandler.TileY + ")", new Vector2(0, arial.LineSpacing), Color.White);
            spriteBatch.DrawString(arial, "SearchX: " + map.searchX, new Vector2(0, arial.LineSpacing * 2), Color.White);
            spriteBatch.DrawString(arial, "SearchY: " + map.searchY, new Vector2(0, arial.LineSpacing * 3), Color.White);

            spriteBatch.DrawString(arial, debugString, new Vector2(6, graphics.PreferredBackBufferHeight - (arial.LineSpacing + 6)), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
