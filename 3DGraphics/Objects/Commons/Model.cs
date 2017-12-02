using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects.Commons
{
    static class ModelObject
    {
        public static void DrawModel(this IModelObject m, Matrix view, Matrix projection, Vector3 pos)
        {
            foreach (ModelMesh mesh in m.Model.Meshes)
            {
                foreach (var part in mesh.MeshParts)
                {
                    part.Effect = m.Effect.Effect;
                }

                mesh.Draw();
            }
        }
}
}
