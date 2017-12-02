using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using _3DGraphics.Effects;

namespace _3DGraphics.Objects.Commons
{
    interface IModelObject
    {
        Model Model { get; }
        EffectBase Effect { get; }
    }
}
