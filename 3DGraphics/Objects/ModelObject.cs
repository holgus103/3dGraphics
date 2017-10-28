using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects
{
    abstract class ModelObject : ObjectBase
    {
        protected abstract Model Model { get; }
        protected float scale;

        public ModelObject(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(position, xRotation, yRotation, zRotation)
        {
            this.scale = scale;
        }

        public override void Draw(Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = Matrix.CreateScale(this.scale) * this.rotaiton * Matrix.CreateTranslation(this.position);
                    effect.View = view;
                    effect.Projection = projection;
                }

                mesh.Draw();
            }

        }
    }
}
