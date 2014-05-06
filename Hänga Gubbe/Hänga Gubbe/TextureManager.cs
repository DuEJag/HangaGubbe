﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Hänga_Gubbe
{
    class TextureManager
    {
        public static Texture2D buttonTex, hillTex, cloudTex;
        public static Texture2D hangmanTex;
        public static SpriteFont font;
        public TextureManager(ContentManager Content)
        {
            buttonTex = Content.Load<Texture2D>("Button2");
            hangmanTex = Content.Load<Texture2D>("hangman");
            hillTex = Content.Load<Texture2D>("Kullar");
            cloudTex = Content.Load<Texture2D>("Moln");

            font = Content.Load<SpriteFont>("SpriteFont2");
        }

    }
}
