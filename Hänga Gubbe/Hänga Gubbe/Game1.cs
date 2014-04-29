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
        Texture2D tex;
        WordManager wordManager = new WordManager();
        ButtonManager buttonManager;
        TextureManager textureManager;
        int integer;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.IsFullScreen = true;

            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //Window.IsBorderless = true;
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //tex = Content.Load<Texture2D>("astroid");
            textureManager = new TextureManager(this.Content);
            buttonManager = new ButtonManager();
            wordManager.LoadContent(this.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            IsMouseVisible = true;
            wordManager.Update();
            buttonManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //spriteBatch.Draw(tex, Vector2.Zero, Color.White);
            buttonManager.Draw(spriteBatch);
            wordManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
