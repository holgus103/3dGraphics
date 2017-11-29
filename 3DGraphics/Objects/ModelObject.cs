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
        protected override string Technique => "TextureTeq";
        protected override Matrix getWorldMatrix() => Matrix.CreateScale(this.scale) * base.getWorldMatrix();

        public ModelObject(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(ctx, position, xRotation, yRotation, zRotation)
        {
            this.scale = scale;
        }

        
        public override void Draw(Matrix view, Matrix projection, Vector3  pos)
        {
            base.Draw(view, projection, pos);
            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (var part in mesh.MeshParts)
                {
                    part.Effect = effect.Effect;
                }

                mesh.Draw();
            }

        }
    }
}
