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
    class TouchKeyboard
    {
        Button[] buttonArray = new Button[29];
        int distance;
        Vector2 keyboardPosition;
        InputManager inputManager;
        bool isTouched = false;
        char myMessage;
        MouseState myMouseState = new MouseState();
        MouseState myOldMouseState = new MouseState();
        float xScale, yScale;
        Button mainMenuButton;
        bool mainMenuIsPressed = false;
        

        public TouchKeyboard()
        {
            this.inputManager = new InputManager();
            //xScale = (float)Decimal.Divide((decimal)1100, (decimal)Game1.scaleX);
            //yScale = (float)Decimal.Divide((decimal)300, (decimal)Game1.scaleY);
            this.distance = (int)Decimal.Divide((decimal)110, (decimal)(Game1.scaleX));
            this.keyboardPosition = GetScalePos(1100, 300);
        }

        private Vector2 GetScalePos(int xValue, int yValue)
        {
            xScale = (float)Decimal.Divide((decimal)xValue, (decimal)Game1.scaleX);
            yScale = (float)Decimal.Divide((decimal)yValue, (decimal)Game1.scaleY);
            return new Vector2(xScale, yScale);
        }

        public void Initialize()
        {
            buttonArray[0] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 0, keyboardPosition.Y + distance * 0), "A");
            buttonArray[1] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 1, keyboardPosition.Y + distance * 0), "B");
            buttonArray[2] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 2, keyboardPosition.Y + distance * 0), "C");
            buttonArray[3] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 3, keyboardPosition.Y + distance * 0), "D");
            buttonArray[4] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 4, keyboardPosition.Y + distance * 0), "E");
            buttonArray[5] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 5, keyboardPosition.Y + distance * 0), "F");
            buttonArray[6] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 0, keyboardPosition.Y + distance * 1), "G");
            buttonArray[7] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 1, keyboardPosition.Y + distance * 1), "H");
            buttonArray[8] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 2, keyboardPosition.Y + distance * 1), "I");
            buttonArray[9] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 3, keyboardPosition.Y + distance * 1), "J");
            buttonArray[10] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 4, keyboardPosition.Y + distance * 1), "K");
            buttonArray[11] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 5, keyboardPosition.Y + distance * 1), "L");
            buttonArray[12] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 0, keyboardPosition.Y + distance * 2), "M");
            buttonArray[13] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 1, keyboardPosition.Y + distance * 2), "N");
            buttonArray[14] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 2, keyboardPosition.Y + distance * 2), "O");
            buttonArray[15] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 3, keyboardPosition.Y + distance * 2), "P");
            buttonArray[16] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 4, keyboardPosition.Y + distance * 2), "Q");
            buttonArray[17] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 5, keyboardPosition.Y + distance * 2), "R");
            buttonArray[18] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 0, keyboardPosition.Y + distance * 3), "S");
            buttonArray[19] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 1, keyboardPosition.Y + distance * 3), "T");
            buttonArray[20] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 2, keyboardPosition.Y + distance * 3), "U");
            buttonArray[21] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 3, keyboardPosition.Y + distance * 3), "V");
            buttonArray[22] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 4, keyboardPosition.Y + distance * 3), "W");
            buttonArray[23] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 5, keyboardPosition.Y + distance * 3), "X");
            buttonArray[24] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 0, keyboardPosition.Y + distance * 4), "Y");
            buttonArray[25] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 1, keyboardPosition.Y + distance * 4), "Z");
            buttonArray[26] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 2, keyboardPosition.Y + distance * 4), "Å");
            buttonArray[27] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 3, keyboardPosition.Y + distance * 4), "Ä");
            buttonArray[28] = new Button(TextureManager.buttonTex, new Vector2(keyboardPosition.X + distance * 4, keyboardPosition.Y + distance * 4), "Ö");
            mainMenuButton = new Button(TextureManager.buttonTex, new Vector2(300, 100), "Back");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button b in buttonArray)
            {
                if (b != null)
                    b.Draw(spriteBatch);
            }
            mainMenuButton.Draw(spriteBatch);
        }

        public void Update()
        {
            foreach (Button b in buttonArray)
            {
                myMouseState = Mouse.GetState();
                if (myMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (b.buttonRec().Intersects(inputManager.MouseRec()))
                    {
                        isTouched = true;
                        myMessage = char.ToLower(b.TextChar());
                        b.Eliminate();
                        //Console.WriteLine(b.TextString());
                    }
                }
                myOldMouseState = myMouseState;
            }

            if (inputManager.MouseRec().Intersects(mainMenuButton.buttonRec()) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                mainMenuIsPressed = true;
            }
        }

        public Rectangle MouseRec()
        {
            return new Rectangle((int)(Mouse.GetState().X * Game1.scaleX), (int)(Mouse.GetState().Y * Game1.scaleY), 1, 1);
        }

        public char GetPressedKey()
        {
            if (isTouched == true)
            {
                isTouched = false;

                return myMessage;

            }

            return ' ';
        }

        public bool GetMenuState()
        {
            bool returnValue = mainMenuIsPressed;
            mainMenuIsPressed = false;
            return returnValue;
        }

        public void Reset()
        {
            foreach (Button eachButton in buttonArray)
            {
                eachButton.Reset();
            }
        }
    }
}
