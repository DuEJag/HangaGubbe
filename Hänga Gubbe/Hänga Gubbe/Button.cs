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
    class Button
    {
        Texture2D tex;
        public Vector2 pos;
        Rectangle srcRec;
        string buttonText;
        Vector2 textLength;
        bool isClicked = false;

        //if(this.FUNTION == LETTER){return action = chat.ToLower(buttonText[1])}

        public Button(Texture2D tex, Vector2 pos, string buttonText)
        {
            this.tex = tex;
            this.pos = pos;
            this.srcRec = new Rectangle(0, 0, tex.Width, tex.Height);
            this.buttonText = buttonText;
            this.textLength = TextureManager.font.MeasureString(buttonText);
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isClicked == false)
            {
                spriteBatch.Draw(tex, new Vector2(buttonRec().X, buttonRec().Y), Color.White);
                spriteBatch.DrawString(TextureManager.font, buttonText, new Vector2(buttonRec().X + (tex.Width / 2), buttonRec().Y + (tex.Height / 2)), Color.Black, 0, textLength / 2, 1, SpriteEffects.None, 1);
            }
        }

        public Rectangle buttonRec()
        {
            return new Rectangle((int)(pos.X * Game1.scaleX), (int)(pos.Y * Game1.scaleY), tex.Width, tex.Height);
        }

        public string TextString()
        {
            return buttonText;
        }

        public char TextChar()
        {
            return char.ToLower(buttonText[0]);
        }

        public void Eliminate()
        {
            isClicked = true;
        }

        public void Reset()
        {
            isClicked = false;
        }
    }
}
