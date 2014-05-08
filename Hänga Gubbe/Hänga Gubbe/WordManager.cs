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
        int[] intArr;
        public static List<char> testedChars = new List<char>();
        InputManager inputManager = new InputManager();
        TouchKeyboard touchKeyboard = new TouchKeyboard();
        Hangman theHangman;

        int errors = 0;
        int maxErrors = 10;
        int numberOfWords;

        public WordManager()
        {
            theHangman = new Hangman(new Vector2(250, 400), new Point(11, 0), new Point(150, 250), maxErrors);
            //testedChars.Add(' ');
            //testedChars.Add('t');
            //testedChars.Add('b');
            //testedChars.Add('s');
            //testedChars.Add('d');
            //testedChars.Add('f');
            //testedChars.Add('e');
            //testedChars.Add('B');
            //testedChars.Add('v');
            //testedChars.Add('a');
        }

        public void LoadContent(ContentManager Content)
        {
            touchKeyboard.Initialize();

            sR = new StreamReader(@"Content/Musiker.txt");

            while (!sR.EndOfStream)
            {
                string s = sR.ReadLine();
                strings.Add(s);
            }
            sR.Close();
            numberOfWords = strings.Count;
            wordint = rnd.Next(numberOfWords);
        }

        public void Update()
        {
            inputManager.Update();
            touchKeyboard.Update();
            CheckChars(inputManager.PressedButton());
            CheckChars(touchKeyboard.GetPressedKey());
        }

        void CheckChars(char aChar)
        {
            char pressedLetter = aChar;
            bool isSame = false;

            foreach (char testedChar in testedChars)
            {
                if (pressedLetter == testedChar)
                    isSame = true;


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
            if (errors == maxErrors)
            {
                spriteBatch.DrawString(TextureManager.font, strings[wordint], new Vector2(500, 200), Color.Black); 
            }

            //for (int letterIndex = 0; letterIndex < strings[wordint].Length; letterIndex++)
            //{
            //    foreach (char testedChar in testedChars)
            //    {
            //        if (strings[wordint][letterIndex] == testedChar)
            //        {
            //            //Console.WriteLine("" + strings[wordint][i]);
            //            spriteBatch.DrawString(TextureManager.font, "" + strings[wordint][letterIndex], new Vector2(20 * letterIndex, 300), Color.Black);
            //        }
            //        if (strings[wordint][letterIndex] != ' ')
            //        {
            //            //Console.WriteLine("" + strings[wordint][i]);
            //            spriteBatch.DrawString(TextureManager.font, "_", new Vector2(20 * letterIndex, 300), Color.Black);
            //        }

            //    }
            //}

            spriteBatch.DrawString(TextureManager.font, GetOutputString(), new Vector2(500, 500), Color.White);
            spriteBatch.DrawString(TextureManager.font, "Errors: " + errors, new Vector2(20, 50), Color.Black);
            touchKeyboard.Draw(spriteBatch);
            theHangman.Draw(spriteBatch);
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
                    if (strings[wordint][letterIndex] != ' ')
                    {
                        output += '_';
                    }
                    else
                        output += ' ';
                }
            }

            if (output == strings[wordint])
                Console.WriteLine("You win!");
            if (errors == maxErrors)
                Console.WriteLine("You Lose!");

            return output;
        }
    }
}
