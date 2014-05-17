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
    class TextureManager
    {
        public static Texture2D buttonTex, hillTex, cloudTex, buttonTex4x1, buttonTex2x1, backbuttonTex, spacebuttonTex;
        public static Texture2D hangmanTex, titelTex, keyBackGround;
        public static SpriteFont font, fontStor;
        public TextureManager(ContentManager Content)
        {
            buttonTex = Content.Load<Texture2D>("Button18");
            buttonTex4x1 = Content.Load<Texture2D>("Button4x1");
            buttonTex2x1 = Content.Load<Texture2D>("Button2x1");
            backbuttonTex = Content.Load<Texture2D>("Buttonback");
            spacebuttonTex = Content.Load<Texture2D>("Buttonspace");
            hangmanTex = Content.Load<Texture2D>("hangman");
            hillTex = Content.Load<Texture2D>("Kullar");
            cloudTex = Content.Load<Texture2D>("MolnV3");
            titelTex = Content.Load<Texture2D>("TitelTest2");
            keyBackGround = Content.Load<Texture2D>("Bakgrund2");

            font = Content.Load<SpriteFont>("sffontbmp36");
            fontStor = Content.Load<SpriteFont>("sffontbmpStor");
        }

    }
}
