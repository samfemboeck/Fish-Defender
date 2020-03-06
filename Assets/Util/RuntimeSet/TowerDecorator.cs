using UnityEngine;

public class TowerDecorator : ComponentDecorator<Tower>
{
    public TowerDecorator(GameObjectSet set) : base(set)
    {
    }

    public Tower GetByIndex(int index)
    {
        foreach (GameObject gameObject in set.items)
        {
            Tower tower;
            if (TryGetComponent(gameObject, out tower) && tower.index == index)
                return tower;
        }
        return null;
    }

    public void SpawnProjectiles()
    {
        foreach (GameObject gameObject in set.items)
        {
            Tower tower;
            if (TryGetComponent(gameObject, out tower))
                tower.SpawnProjectile();
        }
    }
}
