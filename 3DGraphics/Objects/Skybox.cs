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
        protected static EffectBase effect;

        protected override void initEffect(ContentManager ctx)
        {
            if (effect == null)
            {
                effect = new SkyBoxShader(ctx);
            }
        }

        public Skybox(ContentManager ctx) : base(ctx)
        {
            if (model == null)
            {
                model = ctx.Load<Model>("Models\\cube");
            }
        }

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {

            base.Draw(view, projection, pos);
            this.DrawModel(view, projection, pos);
        }

        public TextureCube Texture{ get; set; }
    }
}
