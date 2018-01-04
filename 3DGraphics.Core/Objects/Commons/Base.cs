using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using _3DGraphics.Core.Effects;

namespace _3DGraphics.Core.Objects
{
    public abstract class Base
    {
        public abstract EffectBase Effect { get; }
        protected abstract string Technique { get; }
        protected Vector3 position;
        protected Matrix rotation;

        protected virtual Matrix getWorldMatrix() => this.rotation * Matrix.CreateTranslation(this.position);

        protected abstract void initEffect(ContentManager ctx);

        public virtual void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            Effect.CurrentTechnique = Effect.Techniques[this.Technique];
            Effect.CameraPosition = pos;
            Effect.World = this.getWorldMatrix();
            Effect.View = view;
            Effect.Projection = projection;

        }

        protected Base(ContentManager ctx)
        {
            this.initEffect(ctx);
        }
    }


}
