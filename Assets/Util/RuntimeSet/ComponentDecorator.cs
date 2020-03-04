using UnityEngine;
using System.Collections;

public abstract class ComponentDecorator<T> where T : Component
{
    protected GameObjectSet set;

    public ComponentDecorator(GameObjectSet set)
    {
        this.set = set;
    }

    public bool TryGetComponent(GameObject gameObject, out T t)
    {
        T ret = gameObject.GetComponent<T>();

        if (ret == null)
        {
            t = null;
            return false;
        }

        t = ret;
        return true;
    }
}
