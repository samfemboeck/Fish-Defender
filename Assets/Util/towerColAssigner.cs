using UnityEngine;

public class towerColAssigner : MonoBehaviour
{
    MeshRenderer rend;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponentInChildren<Light>();
        rend = gameObject.GetComponent<MeshRenderer>();
        Color col = gameObject.GetComponent<PlayerColor>().color;
        rend.material.SetColor("_Color", col);
        rend.material.SetColor("EmissionColor", col);
        light.color = col;
    }
}
