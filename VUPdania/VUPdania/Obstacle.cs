using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPdania
{
    class Obstacle : GameObject
    {
        public Obstacle(Vector2 position) : base(position)
        {
        }

        public override void LoadContent()
        {
            sprite = SpriteLibary.Instance.barrels;
            ractangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

    }
}
