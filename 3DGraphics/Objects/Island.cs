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
        private VertexPositionColor[] vetices;
        private BasicEffect effect;
        private const int degree = 30;

        public Island(float radius, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation) : base(position, xRotation, yRotation, zRotation)
        {
            this.effect = new BasicEffect(dev);
            var fragmentVertices = new List<Vector3>(90/degree);
            var v1 = new Vector3(radius, 0, 0);

            this.vetices = new VertexPositionColor[90/degree * 6 * 360/degree];
            //generate fragment
            for (var i = 0; i < 90/degree; i++)
            {
                fragmentVertices.Add(Vector3.Transform(v1, Matrix.CreateRotationZ(MathHelper.ToRadians(degree * i))));
            }

            for (var i = 0; i < 360/degree; i++)
            {
                var f1 = fragmentVertices.Select(e => Vector3.Transform(e, Matrix.CreateRotationY(MathHelper.ToRadians(i * degree)))).ToList();
                var f2 = fragmentVertices.Select(e => Vector3.Transform(e, Matrix.CreateRotationY(MathHelper.ToRadians((i+1) * degree)))).ToList();

                for (var j = 0; j < 90 / degree; j++)
                {
                    var currentVertexNumber = i * 90 / degree * 6 + j * 6;
                    this.vetices[currentVertexNumber] = new VertexPositionColor(f1[0], Color.White);
                    this.vetices[currentVertexNumber + 1] = new VertexPositionColor(f2[0], Color.White);
                    this.vetices[currentVertexNumber + 2] = new VertexPositionColor(f1[1], Color.White);

                    this.vetices[currentVertexNumber + 3] = new VertexPositionColor(f1[0], Color.White);
                    this.vetices[currentVertexNumber + 4] = new VertexPositionColor(f1[0], Color.White);
                    this.vetices[currentVertexNumber + 5] = new VertexPositionColor(f1[0], Color.White);
                }


            }

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
