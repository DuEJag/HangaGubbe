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
        Game1 game1;

        public enum ButtonPressed
        {
            NONE,
            GAME,
            WORD
        }

        List<Button> buttonList;
        ButtonPressed isPressed = ButtonPressed.NONE;

        public MainMenu(Game1 game1)
        {
            this.game1 = game1;

            this.buttonList = new List<Button>();

            string playString = "En Spelare";
            Button playButton = new Button(TextureManager.buttonTex4x1, GetScalePos((1920 / 2 - TextureManager.buttonTex4x1.Width / 2), 
                (1080 / 2 - TextureManager.buttonTex4x1.Height / 2)), playString);
            buttonList.Add(playButton);

            Button twoPlayerButton = new Button(TextureManager.buttonTex4x1, GetScalePos((1920 / 2 - TextureManager.buttonTex4x1.Width / 2),
                (1080 / 2 - TextureManager.buttonTex4x1.Height / 2 + 120)), "Två Spelare");
            buttonList.Add(twoPlayerButton);

            Button addWordButton = new Button(TextureManager.buttonTex4x1, GetScalePos((1920 / 2 - TextureManager.buttonTex4x1.Width / 2),
                (1080 / 2 - TextureManager.buttonTex4x1.Height / 2 + 240)), "Lägg Till Ord");
            buttonList.Add(addWordButton);

            Button exitButton = new Button(TextureManager.buttonTex4x1, GetScalePos((1920 / 2 - TextureManager.buttonTex4x1.Width / 2),
                (1080 / 2 - TextureManager.buttonTex4x1.Height / 2 + 360)), "Avsluta");
            buttonList.Add(exitButton);
        }

        private Vector2 GetScalePos(int xValue, int yValue)
        {
            float xScale = (float)Decimal.Divide((decimal)xValue, (decimal)Game1.scaleX);
            float yScale = (float)Decimal.Divide((decimal)yValue, (decimal)Game1.scaleY);
            return new Vector2(xScale, yScale);
        }

        public void Update()
        {
            //inputManager.Update();
            foreach (Button b in buttonList)
            {
                if (InputManager.MouseRec().Intersects(b.buttonRec()) && InputManager.MouseClick())
                {
                    if(b.TextChar() == 'e')
                        isPressed = ButtonPressed.GAME;

                    if (b.TextChar() == 'l')
                        isPressed = ButtonPressed.WORD;

                    if (b.TextString() == "Avsluta")
                    {
                        game1.Exit();
                    }
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button b in buttonList)
            {
                b.Draw(spriteBatch);
            }
            spriteBatch.Draw(TextureManager.titelTex, new Vector2(460, 150), Color.White);
            //spriteBatch.DrawString(TextureManager.fontStor, "Hänga Gubbe", new Vector2(700, 300), Color.White);
        }

        public ButtonPressed GetMenuMode()
        {
            ButtonPressed returnValue = isPressed;
            isPressed = ButtonPressed.NONE;
            return returnValue;
        }
    }
}
