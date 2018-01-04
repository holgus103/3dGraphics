using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Core.Objects.Commons;

namespace _3DGraphics.Core.Objects
{
    public class Skybox : SkyboxBase
    {

        private static Model model;

        //private float size = 100f;

        public Skybox(ContentManager ctx) : base(ctx)
        {
            model = ctx.Load<Model>("Models\\cube");
        }

        public override Model Model => model;

        protected override string Technique => "Main";



        public override void Draw(Matrix view, Matrix projection, Vector3 cameraPosition)
        {
            this.Effect.GraphicsDevice.RasterizerState = new RasterizerState() {CullMode = CullMode.CullClockwiseFace};

            this.position = cameraPosition;
            base.Draw(view, projection, cameraPosition);

            this.Effect.GraphicsDevice.RasterizerState = new RasterizerState() {CullMode = CullMode.CullCounterClockwiseFace};
        }
    }
}
