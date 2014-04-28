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

        public Button(Texture2D tex, Vector2 pos, Rectangle srcRec)
        {
            this.tex = tex;
            this.pos = pos;
            this.srcRec = srcRec;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
