using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName="GameObjectSet")]
public class GameObjectSet : ScriptableObject
{
    public List<GameObject> items = new List<GameObject>();

    public int Count {
        get
        {
            return items.Count;
        }
    }
    
    public void Add(GameObject gameObject)
    {
        if (!items.Contains(gameObject))
        {
            items.Add(gameObject);
        }
    }

    public GameObject Get(int index)
    {
        return items[index];
    }

    public virtual void Remove(GameObject gameObject)
    {
        if (items.Contains(gameObject))
        {
            items.Remove(gameObject);
            Destroy(gameObject);
        }
    }
    
    public virtual void RemoveAll()
    {
        items.RemoveAll(All);
    }

    private static bool All(GameObject gameObject) 
    {
        Destroy(gameObject);
        return true; 
    }

    private void OnEnable()
    {
        RemoveAll();
    }
}
