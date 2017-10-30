﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects
{
    class VertexObject : ObjectBase
    {
        protected VertexPositionNormalColor[] vertices;
        protected BasicEffect effect;

        protected VertexObject(GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation) : base(position, xRotation, yRotation, zRotation)
        {
            var basicEffectVertexDeclaration = new VertexDeclaration(VertexPositionNormalColor.VertexElements);

            //Enables some basic effect characteristics, such as vertex coloring an ddefault lighting.

            this.effect = new BasicEffect(dev);
            this.effect.VertexColorEnabled = true;
            this.effect.LightingEnabled = true;
            this.effect.EnableDefaultLighting();
        }

        public override void Draw(Matrix view, Matrix projection)
        {
            effect.View = view;
            effect.Projection = projection;
            effect.World = effect.World = this.rotaiton * Matrix.CreateTranslation(this.position);
            foreach (var pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                effect.GraphicsDevice.DrawUserIndexedPrimitives<VertexPositionNormalColor>(PrimitiveType.TriangleList, this.vertices, 0,this.vertices.Length, Enumerable.Range(0, this.vertices.Length).ToArray(), 0, this.vertices.Length / 3);

            }
        }
    }
}
