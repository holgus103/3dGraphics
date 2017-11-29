using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace _3DGraphics.Objects
{
    class VertexObject : ObjectBase
    {
        protected VertexPositionNormalColor[] vertices;

        protected VertexObject(ContentManager ctx, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation) : base(ctx, position, xRotation, yRotation, zRotation)
        {
            //var basicEffectVertexDeclaration = new VertexDeclaration(VertexPositionNormalColor.VertexElements);

        }

        protected override string Technique => "NoTextureTeq";

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            base.Draw(view, projection, pos);
            foreach (var pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                effect.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionNormalColor>(PrimitiveType.TriangleList, this.vertices, 0,this.vertices.Length, Enumerable.Range(0, this.vertices.Length).ToArray(), 0, this.vertices.Length / 3);

            }
        }
    }
}
