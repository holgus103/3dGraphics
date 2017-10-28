using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects
{
    class Sea : VertexObject
    {
        private Camera camera;
        private float level;

        public Sea(Camera camera, float level, GraphicsDevice dev, float diagLength) : base(dev, new Vector3(camera.Position.X, level, camera.Position.Z), 0, 0, 0)
        {
            this.camera = camera;
            this.vertices = new VertexPositionColor[6];

            // 1st triangle
            this.vertices[0] = new VertexPositionColor(new Vector3(diagLength, this.level, diagLength), Color.Navy);
            this.vertices[1] = new VertexPositionColor(new Vector3(-diagLength, this.level, -diagLength), Color.Navy);
            this.vertices[2] = new VertexPositionColor(new Vector3(diagLength, this.level, -diagLength), Color.Navy);
            // 2nd triangle
            this.vertices[4] = new VertexPositionColor(new Vector3(diagLength, this.level, diagLength), Color.Navy);
            this.vertices[3] = new VertexPositionColor(new Vector3(-diagLength, this.level, -diagLength), Color.Navy);
            this.vertices[5] = new VertexPositionColor(new Vector3(-diagLength, this.level, diagLength), Color.Navy);

        }

        public override void Draw(Matrix view, Matrix projection)
        {
            this.position = new Vector3(camera.Position.X, this.level, camera.Position.Z);
            base.Draw(view, projection);
        }
    }
}
