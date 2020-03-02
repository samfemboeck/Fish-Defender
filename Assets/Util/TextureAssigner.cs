using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextureAssigner : MonoBehaviour
{
    MeshRenderer rend;
    public void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
        Color col = gameObject.GetComponentInParent<PlayerColor>().color;
        rend.material.SetColor("_Color", col);
        rend.material.SetColor("_EmissionColor", col);
    }
}
