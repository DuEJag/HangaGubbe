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
        TextureManager textureManager;
        LayerManager layerManager;
        MainMenu mainMenu;
        AddWordMenu addWordMenu;
        float spriteFrame;
        
        public static float scaleX, scaleY; //Scale-variabler som behövs för att få objekt att hamna på rätt plats när man använder annan skärmupplösning än 1080p.

        enum GameState
        {
            MAIN_MENU,
            PLAYING,
            TWO_PLAYER,
            WORD_MENU
        }

        GameState currentGameState = GameState.MAIN_MENU; //Startar spelet på huvudmenyn.

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

            scaleX = (float)Decimal.Divide(1920, GraphicsDevice.DisplayMode.Width); //Skalan ändras utifrån skärmens upplösning
            scaleY = (float)Decimal.Divide(1080, GraphicsDevice.DisplayMode.Height);
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            textureManager = new TextureManager(this.Content);
            addWordMenu = new AddWordMenu();
            wordManager = new WordManager(addWordMenu); //Skickar med addWordMenu för att kunna använda objektet inne i WordManager.
            layerManager = new LayerManager();
            mainMenu = new MainMenu(this);
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            IsMouseVisible = true;

            InputManager.Update();

            spriteFrame += 0.23f;
            if (spriteFrame >= 27)
                spriteFrame = 0;

            MainMenu.ButtonPressed pressedMainMenuButton = mainMenu.GetMenuMode(); //Hämtar vilken knapp i huvudmenyn som spelaren tryckt på.

            if (pressedMainMenuButton == MainMenu.ButtonPressed.GAME)
            {
                currentGameState = GameState.PLAYING;
            }

            if (pressedMainMenuButton == MainMenu.ButtonPressed.WORD)
            {
                addWordMenu.SaveButtonText("Spara");
                currentGameState = GameState.WORD_MENU;
            }

            if (pressedMainMenuButton == MainMenu.ButtonPressed.TWO_PLAYER)
            {
                addWordMenu.SaveButtonText("Spela");
                currentGameState = GameState.TWO_PLAYER;
            }

            if (currentGameState == GameState.PLAYING && wordManager.GetBackButtonValue() == true)
            {
                addWordMenu.Reset();
                addWordMenu.isTwoPlayer = false;
                wordManager.ResetTwoPlayerWord();
                currentGameState = GameState.MAIN_MENU;
            }

            if (currentGameState == GameState.PLAYING && wordManager.GetNewWordButtonValue() == true)
            {
                addWordMenu.Reset();
                addWordMenu.isTwoPlayer = true;
                wordManager.ResetTwoPlayerWord();
                currentGameState = GameState.TWO_PLAYER;
            }

            if (currentGameState == GameState.WORD_MENU && addWordMenu.GetBackButtonValue() == true)
            {
                currentGameState = GameState.MAIN_MENU;
            }

            if (currentGameState == GameState.TWO_PLAYER && addWordMenu.GetBackButtonValue() == true)
            {
                currentGameState = GameState.MAIN_MENU;
            }

            if (currentGameState == GameState.TWO_PLAYER && addWordMenu.GetPlayButtonValue() == true)
            {
                currentGameState = GameState.PLAYING;
            }

            

            layerManager.UpdateClouds();
            wordManager.GetNewWord();

            if (currentGameState == GameState.PLAYING)
            {
                wordManager.Update();
            }

            if (currentGameState == GameState.TWO_PLAYER)
            {
                addWordMenu.isTwoPlayer = true;
                addWordMenu.Update();
            }

            if (currentGameState == GameState.MAIN_MENU)
            {
                addWordMenu.isTwoPlayer = false;
                mainMenu.Update();
                layerManager.Update();
            }

            if (currentGameState == GameState.WORD_MENU)
            {
                addWordMenu.isTwoPlayer = false;
                addWordMenu.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var vWidth = 1920;
            var vHeight = 1080;
            var scale = Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / vWidth, (float)GraphicsDevice.Viewport.Height / vHeight, 1f); //Skalar om alla texturer i spelet till nuvarande skärmupplösning
            GraphicsDevice.Clear(Color.LightBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, scale); //Skickar med den skapade scale-variablen
            spriteBatch.Draw(TextureManager.sunTex, new Vector2(-20, -20), Color.White);
            layerManager.Draw(spriteBatch);

            if (currentGameState == GameState.PLAYING)
                wordManager.Draw(spriteBatch);

            if (currentGameState == GameState.MAIN_MENU)
            {
                spriteBatch.Draw(TextureManager.hangmanTex2, new Vector2(930, 250), new Rectangle(150 * (int)spriteFrame, 0, 150, 200), Color.White);
                mainMenu.Draw(spriteBatch);
            }

            if (currentGameState == GameState.WORD_MENU || currentGameState == GameState.TWO_PLAYER)
                addWordMenu.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
