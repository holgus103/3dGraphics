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
        private static readonly Vector3 Ka = new Vector3(0.2f, 0.2f, 0.2f);
        private static readonly Vector3 Kd = new Vector3(1f, 1f, 1f);
        private static readonly Vector3 Ks = new Vector3(1, 1, 1);
        private const int SHININESS = 100;

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

        protected virtual Matrix getWorldMatrix() =>  this.rotation * Matrix.CreateTranslation(this.position);

        public virtual void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            // TODO: Move to baseobject
            effect.Ka = Ka;
            effect.Kd = Kd;
            effect.Ks = Ks;
            effect.Shininess = SHININESS;
            effect.CameraPosition = pos;
            effect.World = this.getWorldMatrix();
            //part.
            effect.View = view;
            effect.Projection = projection;
        }
    }
}
