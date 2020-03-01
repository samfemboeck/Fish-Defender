using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(menuName="Set/GameObjectSet")]
public class GameObjectSet : RuntimeSet<GameObject> 
{
    public override void Remove(GameObject g)
    {
        base.Remove(g);
        Destroy(g);
    }

    public override void RemoveAll()
    {
        foreach (GameObject g in items.ToArray())
            Remove(g);
    }
}
