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
    class CategoryMenu
    {
        Button[] buttonArray = new Button[4];
        float xScale, yScale;
        int offset = 120, yPos = 300;
        string cathegory = "";

        public CategoryMenu()
        {
            buttonArray[0] = new Button(TextureManager.buttonTex4x1, GetScalePos(1920 / 2 - TextureManager.buttonTex4x1.Width / 2, yPos + offset * 0), "Länder");
            buttonArray[1] = new Button(TextureManager.buttonTex4x1, GetScalePos(1920 / 2 - TextureManager.buttonTex4x1.Width / 2, yPos + offset * 1), "Artister/Band");
            buttonArray[2] = new Button(TextureManager.buttonTex4x1, GetScalePos(1920 / 2 - TextureManager.buttonTex4x1.Width / 2, yPos + offset * 2), "Djur");
            buttonArray[3] = new Button(TextureManager.buttonTex4x1, GetScalePos(1920 / 2 - TextureManager.buttonTex4x1.Width / 2, yPos + offset * 3), "Mina Ord");
        }

        private Vector2 GetScalePos(int xValue, int yValue)
        {
            xScale = (float)Decimal.Divide((decimal)xValue, (decimal)Game1.scaleX);
            yScale = (float)Decimal.Divide((decimal)yValue, (decimal)Game1.scaleY);
            return new Vector2(xScale, yScale);
        }

        public void Update()
        {
            foreach (Button b in buttonArray)
            {
                if (InputManager.MouseRec().Intersects(b.buttonRec()) && InputManager.MouseClick())
                {
                    if (b.TextChar() == 'l')
                        cathegory = "Länder";

                    if (b.TextChar() == 'a')
                        cathegory = "Musiker";

                    if (b.TextChar() == 'd')
                        cathegory = "Ord";

                    if (b.TextChar() == 'm')
                        cathegory = "MinaOrd";
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button b in buttonArray)
            {
                b.Draw(spriteBatch);
            }
        }

        public string Category()
        {
            string returnValue = cathegory;
            cathegory = "";
            return returnValue;
        }
    }
}
