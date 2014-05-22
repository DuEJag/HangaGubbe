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
        Layer hillLayer1, cloudLayer1, hillLayer2, cloudLayer2;
        List<Layer> layerList = new List<Layer>();

        public LayerManager()
        {
            this.cloudLayer1 = new Layer(new Vector2(0, 250), 0.05f, TextureManager.cloudTex2);
            layerList.Add(cloudLayer1);
            this.hillLayer2 = new Layer(new Vector2(0, 350), 0.2f, TextureManager.hillTex2);
            layerList.Add(hillLayer2);
            this.hillLayer1 = new Layer(new Vector2(0, 450), 0.4f, TextureManager.hillTex);
            layerList.Add(hillLayer1);
            this.cloudLayer2 = new Layer(new Vector2(0, 0), 0.15f, TextureManager.cloudTex);
            layerList.Add(cloudLayer2);
        }

        public void Update()
        {
            hillLayer1.Update();
            hillLayer2.Update();


            //foreach (Layer l in layerList)
            //{
            //    l.Update();
            //}
        }

        public void UpdateClouds()
        {
            cloudLayer1.Update();
            cloudLayer2.Update();
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
