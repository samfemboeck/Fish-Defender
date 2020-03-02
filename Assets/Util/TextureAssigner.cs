using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextureAssigner : MonoBehaviour
{
    static int i;
    MeshRenderer rend;
    [SerializeField]
    ColorPool idk;
    public Color[] colours;

    public void Awake()
    {
        colours = new Color[] { idk.color1, idk.color2, idk.color3, idk.color4, idk.color5, idk.color6, idk.color7, idk.color8 };
        rend = gameObject.GetComponent<MeshRenderer>();
        rend.material.SetColor("_Color", colours[i]);
        rend.material.SetColor("_EmissionColor", colours[i]);
        i++;
    }
}
