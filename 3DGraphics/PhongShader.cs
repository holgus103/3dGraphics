using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics
{
    class PhongShader
    {
        private static Effect effect;
        private const string VIEW = "View";
        private const string PROJECTION = "Projection";
        private const string WORLD = "World";

        public PhongShader(Microsoft.Xna.Framework.Content.ContentManager ctx)
        {
            if (effect == null)
            {
                effect = ctx.Load<Effect>("Phong");

            }
        }

        public Effect Effect => PhongShader.effect;

        private Matrix getMatrix(string name) => PhongShader.effect.Parameters[name].GetValueMatrix();
        private void setMatrix(string name, Matrix val) => PhongShader.effect.Parameters[name].SetValue(val);

        public Matrix View
        {
            get
            {
                return this.getMatrix(VIEW);
            }
            set
            {
                this.setMatrix(VIEW, value);
            }
        }

        public Matrix Projection
        {
            get
            {
                return this.getMatrix(PROJECTION);
            }
            set
            {
                this.setMatrix(PROJECTION, value);
            }
        }

        public Matrix World
        {
            get
            {
                return this.getMatrix(WORLD);
            }
            set
            {
                this.setMatrix(PROJECTION, value);
            }
        }

        public EffectTechnique CurrentTechnique => effect.CurrentTechnique;
        public GraphicsDevice GraphicsDevice => effect.GraphicsDevice;
    }
}
