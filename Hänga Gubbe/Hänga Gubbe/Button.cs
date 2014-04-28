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
        Vector2 pos;
        Rectangle srcRec;
        string buttonText;
        Vector2 textLength;

        public Button(Texture2D tex, Vector2 pos, string buttonText)
        {
            this.tex = tex;
            this.pos = pos;
            this.srcRec = new Rectangle(0, 0, 100, 100);
            this.buttonText = buttonText;
        }

        public void Update(GameTime gameTime)
        {
            textLength = TextureManager.font.MeasureString(buttonText);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
            spriteBatch.DrawString(TextureManager.font, buttonText, new Vector2(buttonRec().X + (tex.Width / 2), buttonRec().Y + (tex.Height / 2)), Color.Black, 0, textLength / 2, 1, SpriteEffects.None, 1);
        }

        public Rectangle buttonRec()
        {
            return new Rectangle((int)pos.X, (int)pos.Y, 100, 100);
        }
    }
}
