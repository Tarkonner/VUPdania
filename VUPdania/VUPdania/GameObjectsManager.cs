using System;
using System.Collections.Generic;
using System.Text;

namespace VUPdania
{
    class GameObjectsManager
    {
        //Singelton
        private static readonly Lazy<GameObjectsManager> lazy =
            new Lazy<GameObjectsManager>(() => new GameObjectsManager());
        public static GameObjectsManager Instance { get { return lazy.Value; } }

        //Game object adding & removeing
        static List<GameObject> addedGameObjects = new List<GameObject>();      //For gameobjectets der skal komme i gameObjevt listen
        static List<GameObject> gameObjects = new List<GameObject>();           //For main loop
        static List<GameObject> removingGameObjects = new List<GameObject>();   //For ting der skal fjernes

        #region Properties
        //GameObject
        public List<GameObject> GameObjects { get => gameObjects; set => gameObjects = value; }
        #endregion

        //The Update loop for spawning & despawning things.
        public static void UpdateLoop()
        {
            //Add if new gameobjects is added
            AddGameObjectToWorld();

            //Remove gameobjebts from the list
            RemoveGameObjectFromWorld();
        }


        /// <summary>
        /// Spawn a GameObject on screen. Spawn at end of UpdateLoop.
        /// </summary>
        /// <param name="spawn">The GameObject to spawn</param>
        /// <returns>The GameObject spawned. Need casting for becoming the cast type.</returns>
        public static GameObject Instantiate(GameObject spawn)
        {
            addedGameObjects.Add(spawn);
            return spawn;
        }

        /// <summary>
        /// Destory input GameObject at end of GameObjectManager UpdateLoop
        /// </summary>
        /// <param name="target">The GameObject to destroy</param>
        public static void Destory(GameObject target)
        {
            removingGameObjects.Add(target);
        }

        /// <summary>
        /// Ensures new GameObjects get added to the world.
        /// Also puts GameObjectsWithCollider in collision list.
        /// </summary>
        private static void AddGameObjectToWorld()
        {
            if (addedGameObjects.Count > 0)
            {
                for (int i = 0; i < addedGameObjects.Count; i++)
                {
                    gameObjects.Add(addedGameObjects[i]);
                    addedGameObjects[i].LoadContent();
                }

                addedGameObjects.Clear();
            }
        }

        /// <summary>
        /// Remove GameObjects from world.
        /// Calles onDestroy
        /// </summary>
        private static void RemoveGameObjectFromWorld()
        {
            if (removingGameObjects.Count > 0)
            {
                for (int i = 0; i < removingGameObjects.Count; i++)
                {
                    //Call functions there should be called then destoryed
                    removingGameObjects[i].OnDestroy();

                    //Remove object from gameobjects in the world
                    gameObjects.Remove(removingGameObjects[i]);
                }
                //Clear remove list
                removingGameObjects.Clear();
            }
        }
    }
}
