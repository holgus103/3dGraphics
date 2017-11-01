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

        public ModelObject(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(ctx, position, xRotation, yRotation, zRotation)
        {
            this.scale = scale;
        }

        public override void Draw(Matrix view, Matrix projection)
        {
            effect.Effect.CurrentTechnique = effect.Effect.Techniques["TextureTeq"];
            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (var part in mesh.MeshParts)
                {
                    effect.World = Matrix.CreateScale(this.scale) * this.rotation * Matrix.CreateTranslation(this.position);
                    //part.
                    effect.View = view;
                    effect.Projection = projection;
                    part.Effect = effect.Effect;
                }

                mesh.Draw();
            }

        }
    }
}
