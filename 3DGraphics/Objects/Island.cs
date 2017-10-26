using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects
{
    class Island : ObjectBase
    {
        VertexPositionColor[] vetices = new VertexPositionColor[24];
        private BasicEffect effect;

        public Island(float radius, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation) : base(position, xRotation, yRotation, zRotation)
        {
            //for(var i = 0; i <3; i++)
            //{
                var v1 = position + new Vector3(radius, 0, 0);
                var v2 = Vector3.Transform(v1, Matrix.CreateRotationY(MathHelper.ToRadians(30)));
                var v3 = Vector3.Transform(v1, Matrix.CreateRotationZ(MathHelper.ToRadians(10)));
                var v4 = Vector3.Transform(v3, Matrix.CreateRotationY(MathHelper.ToRadians(30)));
            this.effect = new BasicEffect(dev);
            this.vetices[0] = new VertexPositionColor(v1, Color.White);
            this.vetices[1] = new VertexPositionColor(v2, Color.White);
            this.vetices[2] = new VertexPositionColor(v4, Color.White);
            this.vetices[3] = new VertexPositionColor(v1, Color.White);
            this.vetices[4] = new VertexPositionColor(v3, Color.White);
            this.vetices[5] = new VertexPositionColor(v4, Color.White);
            //}

        }

        public override void Draw(Matrix view, Matrix projection)
        {
            effect.View = view;
            effect.Projection = projection;
            effect.World = effect.World = this.rotaiton * Matrix.CreateTranslation(this.position);
            foreach (var pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                effect.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, this.vetices, 0, 6);
            }
        }
    }
}
