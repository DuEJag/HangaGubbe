using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hänga_Gubbe
{
    class Layer
    {
        Vector2 pos;
        float speed;
        Texture2D tex;

        public Layer(Vector2 pos, float speed, Texture2D tex)
        {
            this.pos = pos;
            this.speed = speed;
            this.tex = tex;
        }

        public void Update()
        {
            pos.X -= speed;
            if (pos.X < -tex.Width)
                pos.X += tex.Width;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos + new Vector2(0, -50), Color.White);
            if (pos.X + tex.Width < 2000)
                sb.Draw(tex, pos + new Vector2(tex.Width, -50), Color.White);
        }
    }
}
