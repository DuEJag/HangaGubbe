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
        int distance = 110;
        Vector2 keyboardPosition = new Vector2(1100, 300);
        InputManager inputManager;
        bool isTouched = false;
        char myMessage;
        MouseState myMouseState = new MouseState();
        MouseState myOldMouseState = new MouseState();

        public TouchKeyboard()
        {
            this.inputManager = new InputManager();
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button b in buttonArray)
            {
                if (b != null)
                    b.Draw(spriteBatch);
            }
        }

        public void Update()
        {
            foreach (Button b in buttonArray)
            {
                myMouseState = Mouse.GetState();
                if (myMouseState.LeftButton == ButtonState.Pressed)
                {
                    if (b.buttonRec().Intersects(MouseRec()))
                    {
                        isTouched = true;
                        myMessage = char.ToLower(b.TextChar());
                        //Console.WriteLine(b.TextString());
                    }
                }
                myOldMouseState = myMouseState;
            }
        }

        public Rectangle MouseRec()
        {
            return new Rectangle((int)Mouse.GetState().X, (int)Mouse.GetState().Y, 1, 1);
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
    }
}
