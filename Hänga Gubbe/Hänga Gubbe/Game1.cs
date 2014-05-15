#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;
#endregion

namespace Hänga_Gubbe
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        WordManager wordManager;
        ButtonManager buttonManager;
        TextureManager textureManager;
        LayerManager layerManager;
        MainMenu mainMenu;
        AddWordMenu addWordMenu;
        
        public static float scaleX, scaleY;

        enum GameState
        {
            MAIN_MENU,
            PLAYING,
            WORD_MENU
        }

        GameState currentGameState = GameState.MAIN_MENU;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            //graphics.PreferredBackBufferHeight = 1080;
            //graphics.PreferredBackBufferWidth = 1920;
            graphics.IsFullScreen = true;

            scaleX = (float)Decimal.Divide(1920, GraphicsDevice.DisplayMode.Width);
            scaleY = (float)Decimal.Divide(1080, GraphicsDevice.DisplayMode.Height);
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Window.IsBorderless = true;


            spriteBatch = new SpriteBatch(GraphicsDevice);
            //tex = Content.Load<Texture2D>("astroid");
            textureManager = new TextureManager(this.Content);
            wordManager = new WordManager();
            buttonManager = new ButtonManager();
            layerManager = new LayerManager();
            mainMenu = new MainMenu();
            addWordMenu = new AddWordMenu();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            IsMouseVisible = true;

            InputManager.Update();

            MainMenu.ButtonPressed pressedMainMenuButton = mainMenu.GetMenuMode();

            if (pressedMainMenuButton == MainMenu.ButtonPressed.GAME)
            {
                currentGameState = GameState.PLAYING;
            }

            if (pressedMainMenuButton == MainMenu.ButtonPressed.WORD)
            {
                currentGameState = GameState.WORD_MENU;
            }

            if (currentGameState == GameState.PLAYING && wordManager.GetMenuState() == true)
            {
                currentGameState = GameState.MAIN_MENU;
            }

            if (currentGameState == GameState.WORD_MENU && addWordMenu.GetMenuState() == true)
            {
                currentGameState = GameState.MAIN_MENU;
            }

            buttonManager.Update(gameTime);
            layerManager.Update();

            if (currentGameState == GameState.PLAYING)
            {
                wordManager.Update();
            }

            if (currentGameState == GameState.MAIN_MENU)
            {
                mainMenu.Update();
            }

            if (currentGameState == GameState.WORD_MENU)
            {
                addWordMenu.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var vWidth = 1920;
            var vHeight = 1080;
            var scale = Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / vWidth, (float)GraphicsDevice.Viewport.Height / vHeight, 1f);
            //Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / vWidth, (float)GraphicsDevice.Viewport.Height / vHeight, 1f)
            GraphicsDevice.Clear(Color.LightBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, scale);
            layerManager.Draw(spriteBatch);
            //spriteBatch.Draw(tex, Vector2.Zero, Color.White);
            buttonManager.Draw(spriteBatch);

            if (currentGameState == GameState.PLAYING)
                wordManager.Draw(spriteBatch);

            if (currentGameState == GameState.MAIN_MENU)
                mainMenu.Draw(spriteBatch);

            if (currentGameState == GameState.WORD_MENU)
                addWordMenu.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
