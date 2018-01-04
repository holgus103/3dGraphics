using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Core.Effects;

namespace _3DGraphics.Core.Objects.Commons
{
    public abstract class SkyboxBase: Base, IModelObject
    {
        protected float size = 100f;
        protected static TextureCube tx;
        protected static SkyBoxShader effect;
        public abstract Model Model { get; }
        public override EffectBase Effect => effect;

        protected SkyboxBase(ContentManager ctx) : base(ctx)
        {
            if (tx == null)
            {
                tx = ctx.Load<TextureCube>("Images\\Skybox");
            }
        }

        protected override void initEffect(ContentManager ctx)
        {
            if (effect == null)
            {
                effect = new SkyBoxShader(ctx);
            }
        }

        protected override Matrix getWorldMatrix() => Matrix.CreateScale(size) * Matrix.CreateTranslation(this.position);

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {

            base.Draw(view, projection, pos);
            effect.Texture = tx;
            this.DrawModel(view, projection, pos);
        }
    }
}
