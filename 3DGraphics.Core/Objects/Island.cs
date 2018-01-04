using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Core.Objects.Commons;

namespace _3DGraphics.Core.Objects
{
    public class Island : VertexPhongObject<VertexPositionNormalColor>
    {
        private int degree;

        private Vector3 getNormalVector(Vector3 point)
        {
            var normal = new Vector3(point.X, point.Y, point.Z);
            normal.Normalize();
            return normal;
        }

        public Island(ContentManager ctx, float noise, float curvyness, int degree, float radius, GraphicsDevice dev,
            Vector3 position, float xRotation, float yRotation, float zRotation) : base(ctx, dev, position, xRotation,
            yRotation, zRotation)
        {
            var map = new PerlinNoise(new Random().Next(), 2 * 90 / degree + 1, 2 * 90 / degree + 1, 1, 1, 1).getMap();
            this.degree = degree;
            var fragmentVertices = new List<Vector3>(90 / degree + 1);
            var v1 = new Vector3(radius, 0, 0);

            this.vertices = new VertexPositionNormalColor[(360 / degree + 1) * (90 / degree + 1) * 6];
            //generate fragment
            for (var i = 0; i <= 90 / degree; i++)
            {
                fragmentVertices.Add(Vector3.Multiply(
                    Vector3.Transform(v1, Matrix.CreateRotationZ(MathHelper.ToRadians(degree * i))),
                    1 - curvyness * (float) Math.Sin(MathHelper.ToRadians(i * degree))));
            }

            for (var i = 0; i < 360 / degree; i++)
            {
                var f1 = fragmentVertices.Select(e =>
                        Vector3.Transform(e, Matrix.CreateRotationY(MathHelper.ToRadians(i * degree))))
                    .Select(v => new Vector3(v.X, v.Y + noise * getShift(degree, radius, map, v.X, v.Z), v.Z))
                    .ToList();
                var f2 = fragmentVertices.Select(e =>
                        Vector3.Transform(e, Matrix.CreateRotationY(MathHelper.ToRadians((i + 1) * degree))))
                    .Select(v => new Vector3(v.X, v.Y + noise * getShift(degree, radius, map, v.X, v.Z), v.Z))
                    .ToList();

                for (var j = 0; j < 90 / degree; j++)
                {
                    var currentVertexNumber = i * 90 / degree * 6 + j * 6;
                    var normal = this.getNormalVector(f1[0 + j]);
                    this.vertices[currentVertexNumber] = new VertexPositionNormalColor(f1[0 + j], normal, Color.SandyBrown);
                    normal = this.getNormalVector(f2[0 + j]);
                    this.vertices[currentVertexNumber + 2] = new VertexPositionNormalColor(f2[0 + j], normal, Color.SandyBrown);
                    normal = this.getNormalVector(f1[1 + j]);
                    this.vertices[currentVertexNumber + 1] = new VertexPositionNormalColor(f1[1 + j], normal, Color.SandyBrown);

                    normal = this.getNormalVector(f1[1 + j]);
                    this.vertices[currentVertexNumber + 4] = new VertexPositionNormalColor(f1[1 + j], normal, Color.SandyBrown);
                    normal = this.getNormalVector(f2[0 + j]);
                    this.vertices[currentVertexNumber + 3] = new VertexPositionNormalColor(f2[0 + j], normal, Color.SandyBrown);
                    normal = this.getNormalVector(f2[1 + j]);
                    this.vertices[currentVertexNumber + 5] = new VertexPositionNormalColor(f2[1 + j], normal, Color.SandyBrown);
                }


            }
            //for (var i = 0; i < 360 / degree; i++)
            //{
            //    var index = i * 90 / degree * 6;
            //    var indexN = (i + 1) * 90 / degree * 6;
            //    if (indexN > 360 / degree)
            //    {
            //        indexN = 0;
            //    }
            //    // handle bottom
            //    this.vertices[index].Normal = (this.vertices[index].Normal + this.vertices[indexN + 2].Normal + this.vertices[indexN + 3].Normal) / 3;

            //    for (var j = 1; j < 90 / degree; j++)
            //    {
            //        var layerShift = 6 * j;
            //        this.vertices[index + layerShift].Normal = (
            //                                                       this.vertices[index + layerShift].Normal +
            //                                                       this.vertices[index + layerShift - 2].Normal +
            //                                                       this.vertices[index + layerShift - 5].Normal +
            //                                                       this.vertices[indexN + layerShift + 2].Normal +
            //                                                       this.vertices[index + layerShift + 3].Normal +
            //                                                       this.vertices[index + layerShift - 1].Normal
            //                                                   ) / 6;
            //    }

            //}


        }

        private static float getShift(int degree, float radius, double[] map, float xCord, float zCord)
        {
            var rowSize = 90 / degree * 2;
            // shift
            var x = xCord + radius;
            var z = zCord + radius;
            // normalize
            x = x / 2 / radius;
            z = z / 2 / radius;
            // get row and column index
            x = x * rowSize;
            z = z * rowSize;
            // calculate final index
            var i = (int)(rowSize * x + z);
            return (float)map[i];
        }
    }
}
