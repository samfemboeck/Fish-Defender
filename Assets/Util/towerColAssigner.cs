using UnityEngine;

public class towerColAssigner : MonoBehaviour
{
    public Material[] m_Mats = new Material[8];
    MeshRenderer rend;
    Light light;
    // Start is called before the first frame update
    public void AssignMat(int i)
    {
        rend = gameObject.GetComponent<MeshRenderer>();
        rend.material = m_Mats[i-1];
    }
    private void Start()
    {
        light = gameObject.GetComponentInChildren<Light>();
        Color col = gameObject.GetComponent<PlayerColor>().color;
        light.color = col;
    }
}
