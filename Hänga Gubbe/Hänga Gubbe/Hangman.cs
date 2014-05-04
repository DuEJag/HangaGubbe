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

        public Hangman(Vector2 pos, Point amountOfFrames, Point frameSize)
        {
            this.pos = pos;
            this.frameSize = frameSize;
            this.amountOfFrames = amountOfFrames;

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
            if (hangmanTex != null)
            {
                spriteBatch.Draw(TextureManager.hangmanTex, pos, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y), Color.White);
            }
        }
    }
}
