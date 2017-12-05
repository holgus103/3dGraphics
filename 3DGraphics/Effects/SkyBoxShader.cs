using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace _3DGraphics.Effects
{
    class SkyBoxShader : EffectBase
    {

        protected const string TEXTURE = "ModelTexture";
        //protected const string INV_MATRIX= "InverseWorldMatrix";
        public SkyBoxShader(ContentManager ctx) : base(ctx, "Shaders\\SkyBoxShader")
        {

        }

        //public Matrix InverseWorldMatrix
        //{
        //    get
        //    {
        //        return this.getMatrix(INV_MATRIX);
        //    }
        //    set
        //    {
        //        this.setMatrix(INV_MATRIX, value);
        //    }
        //}

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
