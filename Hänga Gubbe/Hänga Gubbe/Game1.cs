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
        WordManager wordManager;
        ButtonManager buttonManager;
        TextureManager textureManager;
        LayerManager layerManager;
        public static float scaleX, scaleY;
        
        int integer;
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
            wordManager = new WordManager();
            textureManager = new TextureManager(this.Content);
            buttonManager = new ButtonManager();
            layerManager = new LayerManager();
            wordManager.LoadContent(this.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            IsMouseVisible = true;
            wordManager.Update();
            buttonManager.Update(gameTime);
            layerManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var vWidth = 1920;
            var vHeight = 1080;
            var scale = Matrix.CreateScale((float)GraphicsDevice.Viewport.Width / vWidth, (float)GraphicsDevice.Viewport.Height / vHeight, 1f);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, scale);
            layerManager.Draw(spriteBatch);
            //spriteBatch.Draw(tex, Vector2.Zero, Color.White);
            buttonManager.Draw(spriteBatch);
            wordManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
