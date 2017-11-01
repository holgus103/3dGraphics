using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects
{
    class Sea : VertexObject
    {
        private Camera camera;
        private float level;

        public Sea(ContentManager ctx, Camera camera, float level, GraphicsDevice dev, float diagLength) : base(ctx, dev, new Vector3(camera.Position.X, level, camera.Position.Z), 0, 0, 0)
        {
            this.camera = camera;
            this.vertices = new VertexPositionNormalColor[6];

            // 1st triangle
            this.vertices[0] = new VertexPositionNormalColor(new Vector3(diagLength, this.level, diagLength), Vector3.UnitY, Color.Navy);
            this.vertices[1] = new VertexPositionNormalColor(new Vector3(-diagLength, this.level, -diagLength), Vector3.UnitY, Color.Navy);
            this.vertices[2] = new VertexPositionNormalColor(new Vector3(diagLength, this.level, -diagLength), Vector3.UnitY, Color.Navy);
            // 2nd triangle
            this.vertices[4] = new VertexPositionNormalColor(new Vector3(diagLength, this.level, diagLength), Vector3.UnitY, Color.Navy);
            this.vertices[3] = new VertexPositionNormalColor(new Vector3(-diagLength, this.level, -diagLength), Vector3.UnitY, Color.Navy);
            this.vertices[5] = new VertexPositionNormalColor(new Vector3(-diagLength, this.level, diagLength), Vector3.UnitY, Color.Navy);

        }

        public override void Draw(Matrix view, Matrix projection, Vector3 pos)
        {

            this.position = new Vector3(camera.Position.X, this.level, camera.Position.Z);
            base.Draw(view, projection, pos);
        }
    }
}
