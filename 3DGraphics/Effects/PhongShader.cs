using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Effects
{
    class PhongShader : EffectBase
    {

        private const string KA = "Ka";
        private const string KD = "Kd";
        private const string KS = "Ks";
        private const string SHININESS = "Shininess";
        private const string LIGHT_POSITION = "LightPosition";
        private const string LA = "La";
        private const string LD = "Ld";
        private const string LS = "Ls";
        private const string IS_DIRECT = "IsDirect";

        private const string TEXTURE = "ModelTexture";
        private const string MIXING_TEXTURE = "MixingTexture";
        private const string DISPLACEMENT = "Displacement";

        public PhongShader(Microsoft.Xna.Framework.Content.ContentManager ctx) : base(ctx, "Shaders//Phong")
        {
            Lights.AddLighting(this);
        }

        public Texture2D Texture
        {
            get
            {
                return this.getTexture(TEXTURE);
            }
            set
            {
                this.setTexture(TEXTURE, value);
            }
        }

        public Texture2D MixingTexture
        {
            get
            {
                return this.getTexture(MIXING_TEXTURE);
            }
            set
            {
                this.setTexture(MIXING_TEXTURE, value);
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



        public Vector2 Displacement
        {
            get
            {
                return this.getVector2(DISPLACEMENT);
            }
            set
            {
                this.setVector2(DISPLACEMENT, value);
            }
        }

    }
}
