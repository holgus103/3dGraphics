using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects
{
    class Boat : ModelObject
    {
        private static Model model;

        public Boat(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(ctx, position, xRotation, yRotation, zRotation, scale)
        {
            if (Boat.model == null)
            {
                Boat.model = ctx.Load<Model>("Row_Boat");
            }
        }

        protected override Model Model => Boat.model;
    }
}
