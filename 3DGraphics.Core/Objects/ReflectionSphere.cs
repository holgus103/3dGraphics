using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Core.Objects.Commons;

namespace _3DGraphics.Core.Objects
{
    public class ReflectionSphere : SkyboxBase
    {
        private static Model model;

        public ReflectionSphere(ContentManager ctx, Vector3 position, float size) : base(ctx)
        {
            model = ctx.Load<Model>("Models\\sphere");
            this.position = position;
            this.size = size;
        }

        public override Model Model => model;

        protected override string Technique => "EnvMapping";

        //public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        //{

        //    //effect.InverseWorldMatrix = Matrix.Transpose(Matrix.Invert(this.getWorldMatrix()));
        //    base.Draw(view, projection, pos);

        //}
    }
}
