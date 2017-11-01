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
        private const string KA = "Ka";
        private const string KD = "Kd";
        private const string KS = "Ks";
        private const string SHININESS = "Shininess";
        private const string LIGHT_POSITION = "LightPosition";
        private const string LA = "La";
        private const string LD = "Ld";
        private const string LS = "Ls";

        public PhongShader(Microsoft.Xna.Framework.Content.ContentManager ctx)
        {
                effect = ctx.Load<Effect>("Phong");
        }

        public Effect Effect => PhongShader.effect;

        private Matrix getMatrix(string name) => PhongShader.effect.Parameters[name].GetValueMatrix();
        private Vector3 getVector3(string name) => PhongShader.effect.Parameters[name].GetValueVector3();
        private Vector3[] getVector3Array(string name) => PhongShader.effect.Parameters[name].GetValueVector3Array();
        private void setMatrix(string name, Matrix val) => PhongShader.effect.Parameters[name].SetValue(val);
        private void setVector3(string name, Vector3 val) => PhongShader.effect.Parameters[name].SetValue(val);
        private void setVector3Array(string name, Vector3[] val) => PhongShader.effect.Parameters[name].SetValue(val);

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
                this.setMatrix(WORLD, value);
            }
        }

        public Vector3 Ka
        {
            get
            {
                return this.getVector3(KA);
            }
            set
            {
                this.setVector3(KA, value);
            }
        }

        public Vector3 Kd
        {
            get
            {
                return this.getVector3(KD);
            }
            set
            {
                this.setVector3(KD, value);
            }
        }

        public Vector3 Ks
        {
            get
            {
                return this.getVector3(KS);
            }
            set
            {
                this.setVector3(KS, value);
            }
        }

        public Vector3 Shininess
        {
            get
            {
                return this.getVector3(SHININESS);
            }
            set
            {
                this.setVector3(SHININESS, value);
            }
        }

        public Vector3 La
        {
            get
            {
                return this.getVector3(LA);
            }
            set
            {
                this.setVector3(LA, value);
            }
        }
        public Vector3 Ld
        {
            get
            {
                return this.getVector3(LD);
            }
            set
            {
                this.setVector3(LD, value);
            }
        }
        public Vector3 Ls
        {
            get
            {
                return this.getVector3(LS);
            }
            set
            {
                this.setVector3(LS, value);
            }
        }
        public Vector3 LightPosition
        {
            get
            {
                return this.getVector3(LIGHT_POSITION);
            }
            set
            {
                this.setVector3(LIGHT_POSITION, value);
            }
        }

        public EffectTechnique CurrentTechnique => effect.CurrentTechnique;
        public GraphicsDevice GraphicsDevice => effect.GraphicsDevice;
    }
}
