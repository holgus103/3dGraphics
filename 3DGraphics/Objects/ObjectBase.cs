﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace _3DGraphics.Objects
{
    abstract class ObjectBase
    {
        protected Vector3 position;
        protected Matrix rotaiton;

        protected ObjectBase(Vector3 position, float xRotation, float yRotation, float zRotation)
        {
            this.position = position;
            this.rotaiton = Matrix.CreateRotationX(xRotation) * Matrix.CreateRotationY(yRotation) * Matrix.CreateRotationZ(zRotation);
        }

        public void MoveTo(Vector3 pos)
        {
            this.position = pos;
        }

        public abstract void Draw(Matrix view, Matrix projection);
    }
}
