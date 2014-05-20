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
        Layer backgroundLayer1, backgroundLayer2, backgroundLayer3;
        List<Layer> layerList = new List<Layer>();

        public LayerManager()
        {
            this.backgroundLayer3 = new Layer(new Vector2(0, 350), 0.2f, TextureManager.hillTex2);
            layerList.Add(backgroundLayer3);
            this.backgroundLayer1 = new Layer(new Vector2(0, 450), 0.4f, TextureManager.hillTex);
            layerList.Add(backgroundLayer1);
            this.backgroundLayer2 = new Layer(new Vector2(0, 0), 0.1f, TextureManager.cloudTex);
            layerList.Add(backgroundLayer2);

        }

        public void Update()
        {
            backgroundLayer1.Update();
            backgroundLayer3.Update();


            //foreach (Layer l in layerList)
            //{
            //    l.Update();
            //}
        }

        public void UpdateClouds()
        {
            backgroundLayer2.Update();
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
