using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPdania
{
    class Enemy : GameObject
    {

        protected float speed = 100;
        protected int health = 69;
        protected float rotation;
        protected Cell targetCell;

        public Enemy(Vector2 position) : base(position)
        {
        }

        public override void LoadContent()
        {
            sprite = SpriteLibary.Instance.arrowHead;
            ractangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        private void Dies()
        {
            GameObjectsManager.Destory(this);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Dies();
            }
        }




    }
}
