﻿using System;
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
    class InputManager
    {
        static MouseState mouseState;
        static MouseState oldMouseState;

        public InputManager()
        {
            mouseState = Mouse.GetState();
            oldMouseState = mouseState;
        }

        public static void Update()
        {
            oldMouseState = mouseState;
            mouseState = Mouse.GetState();
        }

        public static Rectangle MouseRec()
        {
            return new Rectangle((int)(Mouse.GetState().X * Game1.scaleX), (int)(Mouse.GetState().Y * Game1.scaleY), 1, 1);
        }

        public static bool MouseClick()
        {
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public Vector2 MousePos2()
        {
            return new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
        }

        public char PressedButton()
        {
            #region PressedChars
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                return 'a';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                return 'b';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                return 'c';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                return 'd';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                return 'e';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                return 'f';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.G))
            {
                return 'g';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.H))
            {
                return 'h';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.I))
            {
                return 'i';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.J))
            {
                return 'j';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                return 'k';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                return 'l';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                return 'm';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.N))
            {
                return 'n';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                return 'o';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                return 'p';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                return 'q';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                return 'r';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                return 's';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                return 't';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.U))
            {
                return 'u';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.V))
            {
                return 'v';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                return 'w';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                return 'x';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Y))
            {
                return 'y';
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                return 'z';
            }
            //if (Keyboard.GetState().IsKeyDown(Keys.Å))
            //{
            //    return 'å';
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Ä))
            //{
            //    return 'ä';
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Ö))
            //{
            //    return 'ö';
            //}
            return ' ';

            #endregion
        }
    }
}
