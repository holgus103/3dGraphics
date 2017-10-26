using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DGraphics.Objects
{
    class PalmTree : ObjectBase
    {
        private static Model model;

        public PalmTree(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation) : base(position, xRotation, yRotation, zRotation)
        {
            if (model == null)
            {
                model = ctx.Load<Model>("Palm1");
            }
        }



        public override void Draw(Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = this.rotaiton * Matrix.CreateTranslation(this.position);
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }

        }

    }
}
