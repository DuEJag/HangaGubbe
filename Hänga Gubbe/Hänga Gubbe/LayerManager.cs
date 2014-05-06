using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hänga_Gubbe
{
    class LayerManager
    {
        Layer backgroundLayer1, backgroundLayer2;
        List<Layer> layerList = new List<Layer>();

        public LayerManager()
        {
            this.backgroundLayer1 = new Layer(new Vector2(0, 500), 0.3f, TextureManager.hillTex);
            layerList.Add(backgroundLayer1);
            this.backgroundLayer2 = new Layer(new Vector2(0, 0), 0.1f, TextureManager.cloudTex);
            layerList.Add(backgroundLayer2);
        }

        public void Update()
        {
            foreach (Layer l in layerList)
            {
                l.Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Layer l in layerList)
            {
                l.Draw(spriteBatch);
            }
        }
    }
}
