using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPdania
{
    class SpriteLibary
    {
        private static readonly Lazy<SpriteLibary> lazy = new Lazy<SpriteLibary>(() => new SpriteLibary());
        public static SpriteLibary Instance { get { return lazy.Value; } }

        public Texture2D arrowHead;
        public Texture2D grass;

        public void LoadContent(ContentManager content)
        {
            arrowHead = content.Load<Texture2D>("arrow_head");
            grass = content.Load<Texture2D>("grass");
        }
    }
}
