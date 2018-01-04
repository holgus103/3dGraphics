using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using _3DGraphics.Core.Effects;

namespace _3DGraphics.Core.Objects.Commons
{
    public abstract class PhongObject : Base
    {
        protected static readonly Vector3 Ka = new Vector3(0.2f, 0.2f, 0.2f);
        protected static readonly Vector3 Kd = new Vector3(1f, 1f, 1f);
        protected static readonly Vector3 Ks = new Vector3(1, 1, 1);
        protected const int SHININESS = 100;

        public override EffectBase Effect => effect;

        //protected Vector3 position;
        //protected Matrix rotation;
        protected static PhongShader effect;
        private Vector3 ka;
        private Vector3 kd;
        private Vector3 ks;
        private int shininess;

        protected PhongObject(ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation) : this(ctx, position, xRotation, yRotation, zRotation, Ka, Kd, Ks)
        {
            
        }

        protected PhongObject(ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, Vector3 ka, Vector3 kd , Vector3 ks , int shininess = SHININESS) : base(ctx)
        {
            this.ka = ka;
            this.ks = ks;
            this.kd = kd;
            this.shininess = shininess;

            this.position = position;
            this.rotation = Matrix.CreateRotationX(xRotation) * Matrix.CreateRotationY(yRotation) * Matrix.CreateRotationZ(zRotation);
        }


        protected override void initEffect(ContentManager ctx)
        {
            if (effect == null)
            {
                effect = new PhongShader(ctx);
            }
        }

        public void MoveTo(Vector3 pos)
        {
            this.position = pos;
        }

        //protected virtual Matrix getWorldMatrix() =>  this.rotation * Matrix.CreateTranslation(this.position);

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            base.Draw(view, projection, pos);
            effect.Effect.CurrentTechnique = effect.Effect.Techniques[this.Technique];
            effect.Ka = this.ka;
            effect.Kd = this.kd;
            effect.Ks = this.ks;
            effect.Shininess = this.shininess;
        }
    }
}
