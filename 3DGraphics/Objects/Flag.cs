using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Objects.Commons;

namespace _3DGraphics.Objects
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
