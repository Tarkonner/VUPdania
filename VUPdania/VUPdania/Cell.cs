using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VUPdania
{
    class Cell : GameObject
    {
        public Cell parent;
        public int g = 0;
        public int h;
        public int f;

        private bool pathable;

        private GameObject holds;

        public Cell(Vector2 position) : base(position)
        {
            parent = this;
        }

        public bool Pathable { get => pathable; set => pathable = value; }


        public override void LoadContent()
        {
            sprite = SpriteLibary.Instance.grass;
            ractangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public void Highlight()
        {
            
        }

        public void Clear()
        {
            if(holds != null)
            {
                GameObjectsManager.Destory(holds);
                holds = null;
            }
            pathable = true;
        }

        public void ResetFGH()
        {
            f = 0;
            g = 0;
            h = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public bool Build(GameObject building)
        {
            if (holds==null)
            {
                holds = building;
                building.position = position;
                pathable = false;
                return true;
            }
            else
            {
                return false;
            }

            
        }


    }
}
