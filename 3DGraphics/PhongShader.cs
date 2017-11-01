using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics
{
    class PhongShader
    {
        private Effect effect;
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
        private const string IS_DIRECT = "IsDirect";
        private const string CAMERA_POSITION = "CameraPosition";

        public PhongShader(Microsoft.Xna.Framework.Content.ContentManager ctx)
        {
            effect = ctx.Load<Effect>("Phong");
        }

        public Effect Effect => this.effect;

        private Matrix getMatrix(string name) => this.effect.Parameters[name].GetValueMatrix();
        private Vector3 getVector3(string name) => this.effect.Parameters[name].GetValueVector3();
        private Vector3[] getVector3Array(string name) => this.effect.Parameters[name].GetValueVector3Array();
        private float[] getScalarArray(string name) => this.effect.Parameters[name].GetValueSingleArray();
        private float getScalar(string name) => this.effect.Parameters[name].GetValueSingle();
        private void setMatrix(string name, Matrix val) => this.effect.Parameters[name].SetValue(val);
        private void setVector3(string name, Vector3 val) => this.effect.Parameters[name].SetValue(val);
        private void setVector3Array(string name, Vector3[] val) => this.effect.Parameters[name].SetValue(val);
        private void setScakarFloat(string name, float[] val) => this.effect.Parameters[name].SetValue(val);
        private void setScalar(string name, float val) => this.effect.Parameters[name].SetValue(val);

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

        public float[] IsDirect
        {
            get
            {
                return this.getScalarArray(IS_DIRECT);
            }
            set
            {
                this.setScakarFloat(IS_DIRECT, value);
            }
        }

        public Vector3 CameraPosition
        {
            get
            {
                return this.getVector3(CAMERA_POSITION);
            }
            set
            {
                this.setVector3(CAMERA_POSITION, value);
            }
        }
        public EffectTechnique CurrentTechnique => effect.CurrentTechnique;
        public GraphicsDevice GraphicsDevice => effect.GraphicsDevice;
    }
}
