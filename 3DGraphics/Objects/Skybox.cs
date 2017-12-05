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

        private static Model model;
        private static TextureCube tx;
        private static SkyBoxShader effect;
        private float size = 50f;

        public Skybox(ContentManager ctx) : base(ctx)
        {
            model = ctx.Load<Model>("Models\\cube");
            tx = ctx.Load<TextureCube>("Images\\Skybox");

        }

        public Model Model => model;
        public override EffectBase Effect => effect;
        protected override string Technique => "Main";

        protected override void initEffect(ContentManager ctx)
        {
            if (effect == null)
            {
                effect = new SkyBoxShader(ctx);
            }
        }

        protected override Matrix getWorldMatrix() => Matrix.CreateScale(size) * Matrix.CreateTranslation(this.position);
        public override void Draw(Matrix view, Matrix projection, Vector3 cameraPosition)
        {
            effect.GraphicsDevice.RasterizerState = new RasterizerState() {CullMode = CullMode.CullClockwiseFace};

            this.position = cameraPosition;
            base.Draw(view, projection, cameraPosition);
            effect.Texture = tx;

            this.DrawModel(view, projection, cameraPosition);
           
            effect.GraphicsDevice.RasterizerState = new RasterizerState() {CullMode = CullMode.CullCounterClockwiseFace};
        }
    }
}
