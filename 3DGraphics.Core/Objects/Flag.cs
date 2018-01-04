using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Core.Objects.Commons;

namespace _3DGraphics.Core.Objects
{
    class Flag : ModelPhongObject
    {
        private static Model model;

        public Flag(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(ctx, position, xRotation, yRotation, zRotation, scale)
        {
            Flag.model = ctx.Load<Model>("Models\\PirateFlag");
        }

        public override Model Model => Flag.model;
    }
}
