using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace VUPdania
{
    abstract class GameObject
    {
        public Rectangle ractangle;

        protected Texture2D sprite;
        protected float spriteLayer = 0;
        protected Vector2 position;
        protected SpriteEffects spriteEffects = new SpriteEffects();

        public Vector2 Origin
        {
            get
            {
                if (sprite != null)
                {
                    return new Vector2(sprite.Width / 2, sprite.Height / 2);
                }
                return Vector2.Zero;
            }
        }

        public Vector2 Position { get { return position; } }

        public GameObject(Vector2 position)
        {
            this.position = position;            
            
        }

        public abstract void LoadContent();

        public virtual void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, ractangle, null, Color.White, 0, Origin, spriteEffects, spriteLayer);
        }

        protected virtual void MoveObject(Vector2 amount)
        {
            position += amount;
            ractangle.X = (int)position.X;
            ractangle.Y = (int)position.Y;
        }

        public virtual void OnDestroy()
        {

        }
    }
}
