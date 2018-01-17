using Microsoft.Xna.Framework.Content;

namespace _3DGraphics.Core.Effects
{
    class RayTracingEffect : EffectBase
    {
        public RayTracingEffect(ContentManager ctx) : base(ctx, "Shaders//RayTracing")
        {
        }
    }
}
