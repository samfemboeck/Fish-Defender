using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public static int instances = 0;

    // Start is called before the first frame update
    void Start()
    {
        instances++;
    }

    private void OnDestroy()
    {
        instances--;
    }
}
