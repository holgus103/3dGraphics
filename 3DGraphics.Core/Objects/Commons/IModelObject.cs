using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Core.Effects;

namespace _3DGraphics.Core.Objects.Commons
{
    interface IModelObject
    {
        Model Model { get; }
        EffectBase Effect { get; }
    }
}
