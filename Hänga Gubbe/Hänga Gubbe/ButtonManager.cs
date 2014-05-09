using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Hänga_Gubbe
{
    class ButtonManager
    {
        Button button;
        Texture2D tex;
        Vector2 pos;
        InputManager inputManager;

        List<Button> buttonList = new List<Button>();

        public ButtonManager()
        {
            this.button = new Button(TextureManager.buttonTex, new Vector2(500, 350), "A");
            buttonList.Add(button);
            inputManager = new InputManager();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Button b in buttonList)
            {
                b.Update(gameTime);
                //if (inputManager.MouseClick() && b.buttonRec().Intersects(inputManager.MousePos()))
                //{
                //    Console.WriteLine("ButtonManager: A Button has been clicked.");
                //}
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //foreach (Button b in buttonList)
            //{
            //    b.Draw(spriteBatch);
            //}
        }
    }
}
