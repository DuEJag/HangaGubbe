using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hänga_Gubbe
{
    class Hangman
    {
        Vector2 pos;

        Texture2D hangmanTex;
        Point amountOfFrames, currentFrame, frameSize;
        int maxErrors;

        public Hangman(Vector2 pos, Point amountOfFrames, Point frameSize, int maxErrors)
        {
            this.pos = pos;
            this.frameSize = frameSize;
            this.amountOfFrames = amountOfFrames;
            this.maxErrors = maxErrors;
            this.currentFrame.X--;

            hangmanTex = TextureManager.hangmanTex;
        }

        //Denna metod kallas på när man vill få nästa del av gubben att visas.
        public void NextFrame()
        {
            if (currentFrame.X < amountOfFrames.X && currentFrame.Y < amountOfFrames.Y)
            {
                currentFrame.X++;

                if (currentFrame.X > amountOfFrames.X -1)
                {
                    currentFrame.Y++;
                    currentFrame.X = 0;
                } 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.hangmanTex, pos, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White);
        }
    }
}
