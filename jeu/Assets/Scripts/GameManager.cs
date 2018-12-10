using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameState state = new GameState();

    public class GameState
    {
        private List<Entity> entities = new List<Entity>();

        public void RegisterEntity(Entity entity)
        {
            Entities.Add(entity);
        }

        public void UnregisterEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        public void CallOnEnabled()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].OnEnabled();
            }
        }

        public void CallDestroy()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Destroy();
            }
        }

        public List<Entity> Entities
        {
            get
            {
                return entities;
            }
        }
    }
}