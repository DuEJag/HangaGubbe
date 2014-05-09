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
    class MainMenu
    {
        List<Button> buttonList;
        InputManager inputManager;
        bool isPressed = false;

        public MainMenu()
        {
            this.buttonList = new List<Button>();
            this.inputManager = new InputManager();
            Button playButton = new Button(TextureManager.buttonTex, GetScalePos((1920 / 2 - TextureManager.buttonTex.Width / 2), (1080 / 2 - TextureManager.buttonTex.Height / 2)), "PLAY");
            buttonList.Add(playButton);
        }

        private Vector2 GetScalePos(int xValue, int yValue)
        {
            float xScale = (float)Decimal.Divide((decimal)xValue, (decimal)Game1.scaleX);
            float yScale = (float)Decimal.Divide((decimal)yValue, (decimal)Game1.scaleY);
            return new Vector2(xScale, yScale);
        }

        public void Update()
        {
            foreach (Button b in buttonList)
            {
                if (inputManager.MouseRec().Intersects(b.buttonRec()) && Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    isPressed = true;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button b in buttonList)
            {
                b.Draw(spriteBatch);
            }
        }

        public bool GetMenuMode()
        {
            bool returnValue = isPressed;
            isPressed = false;
            return returnValue;
        }
    }
}
