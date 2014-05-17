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
        string category = "", word = "", emptyString = "";
        EntryStage currentEntryStage = EntryStage.WORD;

        Button saveButton;
        Button clearButton;
        Button eraseLastCharButton;

        InputManager InputManager;
        FileSaver fileSaver;

        public AddWordMenu()
        {
            this.touchKeyboard = new TouchKeyboard(false);
            this.touchKeyboard.Initialize();

            saveButton = new Button(TextureManager.buttonTex4x1, new Vector2(965, 854), "Spara");
            clearButton = new Button(TextureManager.buttonTex2x1, new Vector2(1365, 854), "Rensa");
            eraseLastCharButton = new Button(TextureManager.backbuttonTex, new Vector2(1458, 734), "");

            InputManager = new InputManager();
            
        }


        public void Update()
        {
            //inputManager.Update();
            touchKeyboard.Update();

            char pressedKey = touchKeyboard.GetPressedKey();

            if (currentEntryStage == EntryStage.CATEGORY)
            {
                if(pressedKey != ' ')
                {
                    category += pressedKey;
                }
            }

            if (currentEntryStage == EntryStage.WORD)
            {
                if (pressedKey != ' ')
                {
                    word += pressedKey;
                }
            }

            EraseLastCharFunction();
            ClearWordFunction();

            if (InputManager.MouseRec().Intersects(saveButton.buttonRec()) && InputManager.MouseClick() == true)
            {
                if (currentEntryStage == EntryStage.CATEGORY)
                {
                    currentEntryStage = EntryStage.WORD;
                }

                if (currentEntryStage == EntryStage.WORD)
                {
                    AddWord();
                    currentEntryStage = EntryStage.EXIT;
                }
            }

            if (currentEntryStage == EntryStage.EXIT)
            {
                currentEntryStage = EntryStage.WORD;

                Reset();
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            touchKeyboard.Draw(spriteBatch);

            spriteBatch.DrawString(TextureManager.fontStor, GetOutputString(), new Vector2(500, 500), Color.DarkSlateGray);

            saveButton.Draw(spriteBatch);
            eraseLastCharButton.Draw(spriteBatch);
            clearButton.Draw(spriteBatch);
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


        public bool GetMenuState()
        {
            if (touchKeyboard.GetMenuState() == true)
            {
                Reset();
                return true;
            }

            return false;
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
            category = "";
            word = "";
        }

        public void EraseLastCharFunction()
        {
            if(InputManager.MouseRec().Intersects(eraseLastCharButton.buttonRec()) && InputManager.MouseClick() == true)
            {
                if(word != emptyString)
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
    }
}
