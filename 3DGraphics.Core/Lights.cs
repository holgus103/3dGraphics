using System.Timers;
using Microsoft.Xna.Framework;
using _3DGraphics.Core.Effects;

namespace _3DGraphics.Core
{
    static class Lights
    {
        private static readonly Vector3 DirectLightDirection = new Vector3(-1, -1, 1);
        private static readonly Vector3 PointLightPosition = new Vector3(0, 45, 0);
        private static readonly Vector3 DirectLightLa = new Vector3(1, 1, 1);
        private static readonly Vector3 PointLightLa = new Vector3(0.5f, 0.5f, 0.5f);
        private static readonly Vector3 DirectLightLd = new Vector3(1, 1, 1);
        private static readonly Vector3 PointLightLd = new Vector3(1, 1, 1);
        private static readonly Vector3 DirectLightLs = new Vector3(1, 1, 1);
        private static readonly Vector3 PointLightLs = new Vector3(1, 1, 1);

        private const int COLOR_INTERVAL = 100;
        public static void AddLighting(PhongShader effect)
        {
            var currentIndex = 0;

            var colors = new[]
            {
                new Vector3(1.0f, 0, 0),
                new Vector3(1.0f, 0.25f, 0),
                new Vector3(1, 0.5f, 0),
                new Vector3(1, 0.75f, 0),
                new Vector3(1, 1, 0),
                new Vector3(1, 0.75f, 0),
                new Vector3(1, 0.5f, 0),
                new Vector3(1, 0.25f, 0),
            };

            // set up lights
            effect.LightPosition = new[] { DirectLightDirection, PointLightPosition };
            effect.La = new[] { DirectLightLa, PointLightLa };
            effect.Ld = new[] { DirectLightLd, PointLightLd };
            effect.Ls = new[] { DirectLightLs, PointLightLs };

            var t = new Timer()
            {
                Interval = COLOR_INTERVAL,
                AutoReset = true,
            };

            t.Elapsed += (o, e) =>
            {
                currentIndex++;
                currentIndex %= colors.Length;
                effect.Ld = new[] { DirectLightLd, colors[currentIndex] };
            };

            t.Start();

            effect.IsDirect = new[] { 1.0f, 0.0f };
        }
    }
}
