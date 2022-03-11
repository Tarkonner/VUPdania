using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace VUPdania
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Enemy testEnemy;
        private Cell testCell;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            SpriteLibary.Instance.LoadContent(Content);

            testCell = (Cell)GameObjectsManager.Instantiate(new Cell(new Vector2(40, 20)));
            testEnemy = (Enemy)GameObjectsManager.Instantiate(new Enemy(new Vector2(20, 20)));
            GameObjectsManager.UpdateLoop();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            for (int i = 0; i < GameObjectsManager.Instance.GameObjects.Count; i++)
            {
                GameObject currentTarget = GameObjectsManager.Instance.GameObjects[i];
                currentTarget.Update(gameTime);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                testEnemy.TakeDamage(10);
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                testCell.Build(GameObjectsManager.Instantiate(new Obstacle(testCell.position)));
            }

            GameObjectsManager.UpdateLoop();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            for (int i = 0; i < GameObjectsManager.Instance.GameObjects.Count; i++)
            {
                GameObject currentTarget = GameObjectsManager.Instance.GameObjects[i];
                currentTarget.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
