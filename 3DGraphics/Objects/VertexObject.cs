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
        protected Effect effect;

        protected VertexObject(ContentManager ctx, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation) : base(position, xRotation, yRotation, zRotation)
        {
            var basicEffectVertexDeclaration = new VertexDeclaration(VertexPositionNormalColor.VertexElements);

            //Enables some basic effect characteristics, such as vertex coloring an ddefault lighting.
            this.effect = ctx.Load<Effect>("Phong");
            //this.effect = new PhongShader(ctx);
            //this.effect = new BasicEffect(dev);
            //this.effect.VertexColorEnabled = true;
            //this.effect.LightingEnabled = true;
            //this.effect.EnableDefaultLighting();
        }

        public override void Draw(Matrix view, Matrix projection)
        {
            effect.Parameters["View"].SetValue(view);
            effect.Parameters["Projection"].SetValue(projection);
            effect.Parameters["World"].SetValue(this.rotation * Matrix.CreateTranslation(this.position));
            foreach (var pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                effect.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionNormalColor>(PrimitiveType.TriangleList, this.vertices, 0,this.vertices.Length, Enumerable.Range(0, this.vertices.Length).ToArray(), 0, this.vertices.Length / 3);

            }
        }
    }
}
