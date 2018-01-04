using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Core.Objects.Commons;

namespace _3DGraphics.Core.Objects
{
    public class Lighthouse : ModelPhongObject
    {
        private static Model model;

        public Lighthouse(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(ctx, position, xRotation, yRotation, zRotation, scale)
        {
            if (Lighthouse.model == null)
            {
                Lighthouse.model = ctx.Load<Model>("Models\\Lighthouse_Lit");
            }
        }

        public override Model Model => Lighthouse.model;
    }
}
