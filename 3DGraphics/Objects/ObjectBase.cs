using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace _3DGraphics.Objects
{
    abstract class ObjectBase
    {
        protected Vector3 position;
        protected Matrix rotation;
        protected static PhongShader effect;

        protected ObjectBase(ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation)
        {
            if (effect == null)
            {
                effect = new PhongShader(ctx);
                Lights.AddLighting(effect);
            }
            this.position = position;
            this.rotation = Matrix.CreateRotationX(xRotation) * Matrix.CreateRotationY(yRotation) * Matrix.CreateRotationZ(zRotation);
        }

        public void MoveTo(Vector3 pos)
        {
            this.position = pos;
        }

        public abstract void Draw(Matrix view, Matrix projection, Vector3 pos);
    }
}
