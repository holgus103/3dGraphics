﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Core.Objects.Commons
{
    public abstract class ModelPhongObject : PhongObject, IModelObject
    { 
        protected override string Technique => "NoTexModel";
        protected override Matrix getWorldMatrix() => Matrix.CreateScale(this.scale) * base.getWorldMatrix();

        public ModelPhongObject(Microsoft.Xna.Framework.Content.ContentManager ctx, Vector3 position, float xRotation, float yRotation, float zRotation, float scale) : base(ctx, position, xRotation, yRotation, zRotation, scale)
        {
        }

        
        public override void Draw(Matrix view, Matrix projection, Vector3  pos)
        {
            base.Draw(view, projection, pos);
            this.DrawModel(view, projection, pos);

        }

        public abstract Model Model { get; }
    }
}
