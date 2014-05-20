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
        Button[] buttonArray = new Button[7];
        float xScale, yScale;
        int offset = 120, yPos = 350, xPos1 = 540, xPos2 = 980, xPos3 = 760;
        string category = "";

        public CategoryMenu()
        {
            buttonArray[0] = new Button(TextureManager.buttonTex4x1, GetScalePos(xPos1, yPos + offset * 0), "Geografi");
            buttonArray[1] = new Button(TextureManager.buttonTex4x1, GetScalePos(xPos1, yPos + offset * 1), "Sport");
            buttonArray[2] = new Button(TextureManager.buttonTex4x1, GetScalePos(xPos1, yPos + offset * 2), "Djur");

            buttonArray[3] = new Button(TextureManager.buttonTex4x1, GetScalePos(xPos2, yPos + offset * 0), "Filmer");
            buttonArray[4] = new Button(TextureManager.buttonTex4x1, GetScalePos(xPos2, yPos + offset * 1), "Historiska personer");
            buttonArray[5] = new Button(TextureManager.buttonTex4x1, GetScalePos(xPos2, yPos + offset * 2), "Artister/Band");

            buttonArray[6] = new Button(TextureManager.buttonTex4x1, GetScalePos(xPos3, yPos + offset * 3), "Mina Ord");
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
                    if (b.TextString() == "Geografi")
                        category = "geografi";

                    if (b.TextString() == "Sport")
                        category = "sport";

                    if (b.TextString() == "Djur")
                        category = "djur";

                    if (b.TextString() == "Filmer")
                        category = "film";

                    if (b.TextString() == "Historiska personer")
                        category = "historiskapersoner";

                    if (b.TextString() == "Artister/Band")
                        category = "Musiker";

                    if (b.TextString() == "Mina Ord")
                        category = "MinaOrd";
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
            string returnValue = category;
            category = "";
            return returnValue;
        }
    }
}
