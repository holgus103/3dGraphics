using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Objects.Commons
{
    static class Textured
    {
        public static void InitTexture(this ITextured tex, string texturePath, GraphicsDevice dev)
        {
            if (tex.Texture == null)
            {
                tex.Texture = tex.LoadTexture(texturePath, dev);
            }
        }

        public static Texture2D LoadTexture(this ITextured tex, string texturePath, GraphicsDevice dev)
        {
            using (var s = File.Open(texturePath, FileMode.Open))
            {
                return Texture2D.FromStream(dev, s);
            }

        }
    }
}
