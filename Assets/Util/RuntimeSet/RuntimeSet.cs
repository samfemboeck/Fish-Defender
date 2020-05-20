using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> items = new List<T>();

    public int Count {
        get
        {
            return items.Count;
        }
    }
    
    public void Add(T t)
    {
        if (!items.Contains(t))
        {
            items.Add(t);
        }
    }

    public virtual void Remove(T t)
    {
        if (items.Contains(t)) items.Remove(t);
    }
    
    public virtual void RemoveAll()
    {
        items.RemoveAll(All);
    }

    private static bool All(T t) { return true; }

    private void OnEnable()
    {
        RemoveAll();
    }

}
