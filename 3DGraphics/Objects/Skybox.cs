using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Effects;
using _3DGraphics.Objects.Commons;

namespace _3DGraphics.Objects
{
    class Skybox : Base, IModelObject
    {

        public Model Model => model;
        public override EffectBase Effect => effect;
        protected static Model model;
        protected override string Technique => "Main";
        protected static SkyBoxShader effect;
        protected static TextureCube tx;
        protected float size;

        protected override void initEffect(ContentManager ctx)
        {
            if (effect == null)
            {
                effect = new SkyBoxShader(ctx);
            }
        }

        public Skybox(ContentManager ctx, float size = 50.0f) : base(ctx)
        {
            if (model == null)
            {
                model = ctx.Load<Model>("Models\\cube");
            }
            if (tx == null)
            {
                tx = ctx.Load<TextureCube>("Images\\Islands");
            }

        }

        protected override Matrix getWorldMatrix() => Matrix.CreateScale(this.size) * Matrix.CreateTranslation(this.position);


        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            this.position = pos;
            effect.Texture = tx;
            effect.GraphicsDevice.RasterizerState = new RasterizerState() {CullMode = CullMode.CullClockwiseFace};
            base.Draw(view, projection, pos);
            this.DrawModel(view, projection, pos);
            effect.GraphicsDevice.RasterizerState = new RasterizerState() { CullMode = CullMode.CullCounterClockwiseFace };

        }
    }
}
