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
            // set up lights
            this.LightPosition = new[] { new Vector3(100, 100, 100), new Vector3(0, 30, 0) };
            this.La = new[] { new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0.5f, 0.5f, 0.5f) };
            this.Ld = new[] { new Vector3(1, 1, 1), new Vector3(1, 1, 1) };
            this.Ls = new[] { new Vector3(0.3f, 0.3f, 0.3f), new Vector3(0.3f, 0.3f, 0.3f) };
            // TODO: Move to baseobject
            this.Ka = new Vector3(0.2f, 0.2f, 0.2f);
            this.Kd = new Vector3(1f, 1f, 1f);
            this.Ks = new Vector3(0.1f, 0.1f, 0.1f);
            this.Shininess = 2;
        }

        public Effect Effect => PhongShader.effect;

        private Matrix getMatrix(string name) => PhongShader.effect.Parameters[name].GetValueMatrix();
        private Vector3 getVector3(string name) => PhongShader.effect.Parameters[name].GetValueVector3();
        private Vector3[] getVector3Array(string name) => PhongShader.effect.Parameters[name].GetValueVector3Array();
        private float getScalar(string name) => PhongShader.effect.Parameters[name].GetValueSingle();
        private void setMatrix(string name, Matrix val) => PhongShader.effect.Parameters[name].SetValue(val);
        private void setVector3(string name, Vector3 val) => PhongShader.effect.Parameters[name].SetValue(val);
        private void setVector3Array(string name, Vector3[] val) => PhongShader.effect.Parameters[name].SetValue(val);
        private void setScalar(string name, float val) => PhongShader.effect.Parameters[name].SetValue(val);

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

        public float Shininess
        {
            get
            {
                return this.getScalar(SHININESS);
            }
            set
            {
                this.setScalar(SHININESS, value);
            }
        }

        public Vector3[] La
        {
            get
            {
                return this.getVector3Array(LA);
            }
            set
            {
                this.setVector3Array(LA, value);
            }
        }
        public Vector3[] Ld
        {
            get
            {
                return this.getVector3Array(LD);
            }
            set
            {
                this.setVector3Array(LD, value);
            }
        }
        public Vector3[] Ls
        {
            get
            {
                return this.getVector3Array(LS);
            }
            set
            {
                this.setVector3Array(LS, value);
            }
        }
        public Vector3[] LightPosition
        {
            get
            {
                return this.getVector3Array(LIGHT_POSITION);
            }
            set
            {
                this.setVector3Array(LIGHT_POSITION, value);
            }
        }

        public EffectTechnique CurrentTechnique => effect.CurrentTechnique;
        public GraphicsDevice GraphicsDevice => effect.GraphicsDevice;
    }
}
