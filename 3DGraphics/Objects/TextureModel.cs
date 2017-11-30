﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Objects.Commons;

namespace _3DGraphics.Objects
{
    abstract class TextureModel : ModelObject, ITextured
    {
        public abstract Texture2D Texture { get; set; }

        protected TextureModel(ContentManager ctx, GraphicsDevice dev, Vector3 position, float xRotation, float yRotation, float zRotation, float scale, string texturePath) : base(ctx, position, xRotation, yRotation, zRotation, scale)
        {
            this.InitTexture(texturePath, dev);
        }

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {
            effect.Texture = this.Texture;
            base.Draw(view, projection, pos);
        }
    }

}
