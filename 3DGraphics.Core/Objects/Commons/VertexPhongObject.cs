using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Core.Objects.Commons
{
    public class VertexPhongObject<T> : PhongObject 
        where T : struct, IVertexType
    {
        protected T[] vertices;

        protected VertexPhongObject(ContentManager ctx, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation) : base(ctx, position, xRotation, yRotation, zRotation)
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
                effect.GraphicsDevice.DrawUserIndexedPrimitives<T>(PrimitiveType.TriangleList, this.vertices, 0,this.vertices.Length, Enumerable.Range(0, this.vertices.Length).ToArray(), 0, this.vertices.Length / 3);

            }
        }
    }
}
