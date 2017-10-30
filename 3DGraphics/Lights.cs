using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics
{
    static class Lights
    {
        
        public static BasicEffect AddLighting(BasicEffect effect)
        {
            effect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f);
            effect.DirectionalLight0.DiffuseColor = new Vector3(0.5f, 0, 0); // a red light
            effect.DirectionalLight0.Direction = new Vector3(1, 0, 0);  // coming along the x-axis
            effect.DirectionalLight0.SpecularColor = new Vector3(0, 1, 0); // with green highlights
            effect.DirectionalLight0.Enabled = true;
            effect.EmissiveColor = new Vector3(1, 0, 0);
            return effect;
        }
    }
}
