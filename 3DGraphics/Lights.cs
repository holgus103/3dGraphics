using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics
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
        private static readonly Vector3 Ka = new Vector3(0.2f, 0.2f, 0.2f);
        private static readonly Vector3 Kd = new Vector3(1f, 1f, 1f);
        private static readonly Vector3 Ks = new Vector3(1, 1, 1);
        private static readonly Vector3 Shinyness = new Vector3(1, 1, 1);
        private const int COLOR_INTERVAL = 100;
        private const int SHINYNESS = 100;
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
            effect.Ls = new[] { DirectLightLs, DirectLightLs };

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

            // TODO: Move to baseobject
            effect.Ka = Ka;
            effect.Kd = Kd;
            effect.Ks = Ks;
            effect.Shininess = SHINYNESS;
            effect.IsDirect = new[] { 1.0f, 0.0f };
        }
    }
}
