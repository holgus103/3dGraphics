using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DGraphics.Objects
{
    class PalmTree
    {
        private static Model model;
        private Vector3 position;
        public PalmTree(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position)
        {
            this.position = position;
            if (model == null)
            {
                model = ctx.Load<Model>("Palm1");
            }
        }

        public void MoveTo(Vector3 pos)
        {
            this.position = pos;
        }
        public void Draw(Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = Matrix.CreateTranslation(this.position);
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }

        }

    }
}
