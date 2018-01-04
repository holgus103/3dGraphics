using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Core.Effects
{
    public class EffectBase : Effect
    {
        private const string VIEW = "View";
        private const string PROJECTION = "Projection";
        private const string WORLD = "World";
        private const string CAMERA_POSITION = "CameraPosition";
        public Effect Effect => this;
        protected Matrix getMatrix(string name) => this.Effect.Parameters[name].GetValueMatrix();
        protected Vector3 getVector3(string name) => this.Effect.Parameters[name].GetValueVector3();
        protected Vector2 getVector2(string name) => this.Effect.Parameters[name].GetValueVector2();
        protected Vector3[] getVector3Array(string name) => this.Effect.Parameters[name].GetValueVector3Array();
        protected float[] getScalarArray(string name) => this.Effect.Parameters[name].GetValueSingleArray();
        protected float getScalar(string name) => this.Effect.Parameters[name].GetValueSingle();
        protected Texture2D getTexture(string name) => this.Effect.Parameters[name].GetValueTexture2D();
        protected TextureCube getTextureCube(string name) => this.Effect.Parameters[name].GetValueTextureCube();
        protected void setMatrix(string name, Matrix val) => this.Effect.Parameters[name].SetValue(val);
        protected void setVector3(string name, Vector3 val) => this.Effect.Parameters[name].SetValue(val);
        protected void setVector2(string name, Vector2 val) => this.Effect.Parameters[name].SetValue(val);
        protected void setVector3Array(string name, Vector3[] val) => this.Effect.Parameters[name].SetValue(val);
        protected void setScakarFloat(string name, float[] val) => this.Effect.Parameters[name].SetValue(val);
        protected void setScalar(string name, float val) => this.Effect.Parameters[name].SetValue(val);
        protected void setTexture(string name, Texture2D tex) => this.Effect.Parameters[name].SetValue(tex);
        protected void setTextureCube(string name, TextureCube tex) => this.Effect.Parameters[name].SetValue(tex);

        protected EffectBase(ContentManager ctx, string path) : base(ctx.Load<Effect>(path))
        {
            
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
    }
}
