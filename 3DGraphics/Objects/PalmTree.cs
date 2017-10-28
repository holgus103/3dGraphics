using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DGraphics.Objects
{
    class PalmTree : ModelObject
    {
        private static Model model;

        public PalmTree(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(ctx, position, xRotation, yRotation, zRotation, scale)
        {
            if (PalmTree.model == null)
            {
                PalmTree.model = ctx.Load<Model>("Palm1");
            }
        }

        protected override Model Model => PalmTree.model;
    }
}
