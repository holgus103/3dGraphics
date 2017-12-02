using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Effects
{
    class SkyBoxShader : EffectBase
    {

        protected const string TEXTURE = "ModelTexture";
        public SkyBoxShader(ContentManager ctx) : base(ctx, "Shaders\\SkyBoxShader")
        {

        }



        public TextureCube Texture
        {
            get
            {
                return this.getTextureCube(TEXTURE);
            }
            set
            {
                this.setTextureCube(TEXTURE, value);
            }
        }
    }
}
