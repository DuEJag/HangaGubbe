using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;

namespace Hänga_Gubbe
{
    class AddWordMenu
    {
        enum EntryStage
        {
            CATEGORY,
            WORD,
            EXIT
        }

        TouchKeyboard touchKeyboard;
        public string category = "", word = "", emptyString = "";
        EntryStage currentEntryStage = EntryStage.WORD;
        bool isBackButtonPressed = false;
        public bool isPlayButtonPressed = false;
        public bool isTwoPlayer = false;

        Button saveButton, clearButton, eraseLastCharButton, spaceButton, backButton;

        InputManager InputManager;
        FileSaver fileSaver;

        public AddWordMenu()
        {
            this.touchKeyboard = new TouchKeyboard(false, new Point(610, 300));
            this.touchKeyboard.Initialize();

            backButton = new Button(TextureManager.buttonTex2x1, GetScalePos(1675, 950), "Tillbaka");
            saveButton = new Button(TextureManager.buttonTex2x1, GetScalePos(670, 950), "Spara");
            clearButton = new Button(TextureManager.buttonTex2x1, GetScalePos(910, 950), "Rensa");
            eraseLastCharButton = new Button(TextureManager.backbuttonTex, GetScalePos(1150, 950), "");
            spaceButton = new Button(TextureManager.spacebuttonTex, GetScalePos(1210, 780), "");
            InputManager = new InputManager();

        }

        public void SaveButtonText(string text)
        {
            saveButton = new Button(TextureManager.buttonTex2x1, GetScalePos(670, 950), text);
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
            touchKeyboard.Update();

            char pressedKey = touchKeyboard.GetPressedKey();

            if (currentEntryStage == EntryStage.CATEGORY)
            {
                if (pressedKey != ' ')
                {
                    category += pressedKey;
                }
            }

            if (currentEntryStage == EntryStage.WORD)
            {
                if (pressedKey != ' ' && word.Length < 30)
                {
                    word += pressedKey;
                }
            }

            EraseLastCharFunction();
            ClearWordFunction();
            AddSpaceFunction();

            if (InputManager.MouseRec().Intersects(saveButton.buttonRec()) && InputManager.MouseClick() == true)
            {
                if (currentEntryStage == EntryStage.CATEGORY)
                {
                    currentEntryStage = EntryStage.WORD;
                }


                if (currentEntryStage == EntryStage.WORD)
                {
                    if (isTwoPlayer == false)
                    {
                        AddWord();
                        Reset();
                    }
                    GetOutputString();
                    isPlayButtonPressed = true;
                    currentEntryStage = EntryStage.EXIT;
                }


            }

            if (currentEntryStage == EntryStage.EXIT && isTwoPlayer == false)
            {
                currentEntryStage = EntryStage.WORD;

                Reset();
            }

            if (InputManager.MouseRec().Intersects(backButton.buttonRec()) && InputManager.MouseClick())
            {
                isBackButtonPressed = true;
            }
        }

        public bool GetBackButtonValue()
        {
            bool returnValue = isBackButtonPressed;
            isBackButtonPressed = false;
            return returnValue;
        }

        public bool GetPlayButtonValue()
        {
            bool returnValue = isPlayButtonPressed;
            isPlayButtonPressed = false;
            return returnValue;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            touchKeyboard.Draw(spriteBatch);

            spriteBatch.DrawString(TextureManager.fontStor, GetOutputString(), new Vector2(960, 100), Color.DarkSlateGray, 0, TextureManager.fontStor.MeasureString(GetOutputString()) / 2, 1, SpriteEffects.None, 1);

            backButton.Draw(spriteBatch);
            saveButton.Draw(spriteBatch);
            eraseLastCharButton.Draw(spriteBatch);
            clearButton.Draw(spriteBatch);
            spaceButton.Draw(spriteBatch);
        }


        public string GetOutputString()
        {
            string output = "";

            if (currentEntryStage == EntryStage.CATEGORY)
            {
                output += category;
            }

            if (currentEntryStage == EntryStage.WORD)
            {
                output += word;
            }

            return output;
        }


        public void AddWord()
        {
            if (word != "")
            {
                fileSaver = new FileSaver("Content", "MinaOrd");
                fileSaver.AddWord(word);
                fileSaver.Save();
            }
        }

        public void Reset()
        {
            currentEntryStage = EntryStage.WORD;
            category = "";
            word = "";
        }

        public void EraseLastCharFunction()
        {
            if (InputManager.MouseRec().Intersects(eraseLastCharButton.buttonRec()) && InputManager.MouseClick() == true)
            {
                if (word != emptyString)
                    word = word.Remove(word.Length - 1);
            }
        }

        public void ClearWordFunction()
        {
            if (InputManager.MouseRec().Intersects(clearButton.buttonRec()) && InputManager.MouseClick() == true)
            {
                Reset();
            }
        }

        public void AddSpaceFunction()
        {
            if (InputManager.MouseRec().Intersects(spaceButton.buttonRec()) && InputManager.MouseClick() == true)
            {
                word = word + " ";
            }
        }
    }
}
