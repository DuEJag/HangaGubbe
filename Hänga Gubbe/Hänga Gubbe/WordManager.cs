using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.IO;

namespace Hänga_Gubbe
{
    class WordManager
    {
        StreamReader sR;

        List<string> strings = new List<string>();
        int wordint;
        Random rnd = new Random();
        public static List<char> testedChars = new List<char>();
        InputManager inputManager = new InputManager();
        TouchKeyboard touchKeyboard = new TouchKeyboard(true, new Point(1150, 300));
        Button backButton, newWordButton;
        Hangman theHangman;
        CategoryMenu categoryMenu;

        int errors = 0;
        int maxErrors = 10;
        int numberOfWords;

        bool isPlaying = true;
        bool categoryChosen = false;
        bool isBackButtonPressed = false;

        public WordManager()
        {
            theHangman = new Hangman(new Vector2(250, 400), new Point(12, 0), new Point(150, 250), maxErrors);
            newWordButton = new Button(TextureManager.buttonTex2x1, GetScalePos(1425, 950), "Nytt ord");
            backButton = new Button(TextureManager.buttonTex2x1, GetScalePos(1675, 950), "Tillbaka");
            categoryMenu = new CategoryMenu();
        }

        private Vector2 GetScalePos(int xValue, int yValue)
        {
            float xScale = (float)Decimal.Divide((decimal)xValue, (decimal)Game1.scaleX);
            float yScale = (float)Decimal.Divide((decimal)yValue, (decimal)Game1.scaleY);
            return new Vector2(xScale, yScale);
        }

        private void Initialize(string category)
        {
            touchKeyboard.Initialize();
            strings.Clear();
            sR = new StreamReader(@"Content/" + category + ".txt");


            while (!sR.EndOfStream)
            {
                string s = sR.ReadLine();
                strings.Add(s);
            }
            sR.Close();
            numberOfWords = strings.Count;
            wordint = rnd.Next(strings.Count);

        }

        public void Update()
        {
            //inputManager.Update();

            string category = categoryMenu.Category();

            if (categoryChosen == false && category != "")
            {
                categoryChosen = true;
                Initialize(category);
            }
            

            if (categoryChosen == true)
            {
                if (errors >= maxErrors || GetOutputString() == strings[wordint])
                {
                    isPlaying = false;
                }
                
                if (isPlaying == true)
                {
                    touchKeyboard.Update();
                    CheckChars(inputManager.PressedButton());
                    CheckChars(touchKeyboard.GetPressedKey());
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && isPlaying == false)
                {
                    ResetWord();
                    isPlaying = true;
                }
            }
            else
            {
                categoryMenu.Update();
            }

            if (InputManager.MouseRec().Intersects(backButton.buttonRec()) && InputManager.MouseClick())
            {
                isBackButtonPressed = true;
                categoryChosen = false;
                //Initialize(category);
                ResetWord();
            }

            if (InputManager.MouseRec().Intersects(newWordButton.buttonRec()) && InputManager.MouseClick())
            {
                ResetWord();
            }
        }

        void CheckChars(char aChar)
        {
            char pressedLetter = aChar;
            bool isSame = false;

            foreach (char testedChar in testedChars)
            {
                if (pressedLetter == testedChar)
                {
                    isSame = true;
                }
            }



            #region CharCheck
            if (isSame == false)
            {


                if (pressedLetter == 'a')
                {
                    testedChars.Add('a');
                    testedChars.Add('A');

                }
                if (pressedLetter == 'b')
                {
                    testedChars.Add('b');
                    testedChars.Add('B');
                }
                if (pressedLetter == 'c')
                {
                    testedChars.Add('c');
                    testedChars.Add('C');
                }
                if (pressedLetter == 'd')
                {
                    testedChars.Add('d');
                    testedChars.Add('D');
                }
                if (pressedLetter == 'e')
                {
                    testedChars.Add('e');
                    testedChars.Add('E');
                }
                if (pressedLetter == 'f')
                {
                    testedChars.Add('f');
                    testedChars.Add('F');
                }
                if (pressedLetter == 'g')
                {
                    testedChars.Add('g');
                    testedChars.Add('G');
                }
                if (pressedLetter == 'h')
                {
                    testedChars.Add('h');
                    testedChars.Add('H');
                }
                if (pressedLetter == 'i')
                {
                    testedChars.Add('i');
                    testedChars.Add('I');
                }
                if (pressedLetter == 'j')
                {
                    testedChars.Add('j');
                    testedChars.Add('J');
                }
                if (pressedLetter == 'k')
                {
                    testedChars.Add('k');
                    testedChars.Add('K');
                }
                if (pressedLetter == 'l')
                {
                    testedChars.Add('l');
                    testedChars.Add('L');
                }
                if (pressedLetter == 'm')
                {
                    testedChars.Add('m');
                    testedChars.Add('M');
                }
                if (pressedLetter == 'n')
                {
                    testedChars.Add('n');
                    testedChars.Add('N');
                }
                if (pressedLetter == 'o')
                {
                    testedChars.Add('o');
                    testedChars.Add('O');
                }
                if (pressedLetter == 'p')
                {
                    testedChars.Add('p');
                    testedChars.Add('P');
                }
                if (pressedLetter == 'q')
                {
                    testedChars.Add('q');
                    testedChars.Add('Q');
                }
                if (pressedLetter == 'r')
                {
                    testedChars.Add('r');
                    testedChars.Add('R');
                }
                if (pressedLetter == 's')
                {
                    testedChars.Add('s');
                    testedChars.Add('S');
                }
                if (pressedLetter == 't')
                {
                    testedChars.Add('t');
                    testedChars.Add('T');
                }
                if (pressedLetter == 'u')
                {
                    testedChars.Add('u');
                    testedChars.Add('U');
                }
                if (pressedLetter == 'v')
                {
                    testedChars.Add('v');
                    testedChars.Add('V');
                }
                if (pressedLetter == 'w')
                {
                    testedChars.Add('w');
                    testedChars.Add('W');
                }
                if (pressedLetter == 'x')
                {
                    testedChars.Add('x');
                    testedChars.Add('X');
                }
                if (pressedLetter == 'y')
                {
                    testedChars.Add('y');
                    testedChars.Add('Y');
                }
                if (pressedLetter == 'z')
                {
                    testedChars.Add('z');
                    testedChars.Add('Z');
                }
                if (pressedLetter == 'å')
                {
                    testedChars.Add('å');
                    testedChars.Add('Å');
                }
                if (pressedLetter == 'ä')
                {
                    testedChars.Add('ä');
                    testedChars.Add('Ä');
                }
                if (pressedLetter == 'ö')
                {
                    testedChars.Add('ö');
                    testedChars.Add('Ö');
                }

                if (pressedLetter != ' ')
                {
                    bool isCorrect = false;

                    for (int letterIndex = 0; letterIndex < strings[wordint].Length; letterIndex++)
                    {
                        if (char.ToLower(strings[wordint][letterIndex]) == pressedLetter)
                        {
                            isCorrect = true;
                        }
                    }

                    if (isCorrect == false)
                    {
                        errors += 1;
                        theHangman.NextFrame();

                    }
                    //Console.WriteLine(errors);
                }
            }
            #endregion

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (categoryChosen == true)
            {
                if (errors == maxErrors)
                {
                    spriteBatch.DrawString(TextureManager.font, strings[wordint], new Vector2(500, 200), Color.Black);
                }

                spriteBatch.DrawString(TextureManager.fontStor, GetOutputString(), new Vector2(960, 100), Color.DarkSlateGray, 0, TextureManager.fontStor.MeasureString(GetOutputString()) / 2, 1, SpriteEffects.None, 1);
                spriteBatch.DrawString(TextureManager.font, "Errors: " + errors, new Vector2(20, 50), Color.Black);
                touchKeyboard.Draw(spriteBatch);
                theHangman.Draw(spriteBatch);
                newWordButton.Draw(spriteBatch);
            }
            else
            {
                categoryMenu.Draw(spriteBatch);
            }

            backButton.Draw(spriteBatch);
            
        }

        public bool GetBackButtonValue()
        {
            bool returnValue = isBackButtonPressed;
            isBackButtonPressed = false;
            return returnValue;
        }

        public string GetOutputString()
        {
            string output = "";

            for (int letterIndex = 0; letterIndex < strings[wordint].Length; letterIndex++)
            {
                bool solvedLetter = false;

                foreach (char testedChar in testedChars)
                {
                    if (strings[wordint][letterIndex] == testedChar)
                    {
                        solvedLetter = true;
                    }
                }

                if (solvedLetter == true)
                {
                    output += strings[wordint][letterIndex];
                }
                else
                {
                    if (strings[wordint][letterIndex] != ' ' && strings[wordint][letterIndex] != '-')
                        output += '_';
                    if (strings[wordint][letterIndex] == ' ')
                        output += ' ';
                    if (strings[wordint][letterIndex] == '-')
                        output += '-';
                }
            }

            if (output == strings[wordint])
                Console.WriteLine("You win!");
            if (errors == maxErrors)
                Console.WriteLine("You Lose!");

            return output;
        }


        public void ResetWord()
        {
            isPlaying = true;
            errors = 0;
            maxErrors = 10;
            testedChars = new List<char>();
            theHangman = new Hangman(new Vector2(250, 400), new Point(12, 0), new Point(150, 250), maxErrors);
            wordint = rnd.Next(numberOfWords);
            if (categoryChosen == true)
            {
                touchKeyboard.Reset(); 
            }
        }
    }
}
