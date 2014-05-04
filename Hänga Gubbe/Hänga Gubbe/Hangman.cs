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

            currentFrame.X = amountOfFrames.X - maxErrors -1;

            hangmanTex = TextureManager.hangmanTex;
        }

        public void NextFrame()
        {
            if (currentFrame.X < amountOfFrames.X -1)
            {
                currentFrame.X++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.hangmanTex, pos, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White);
            
        }
    }
}
