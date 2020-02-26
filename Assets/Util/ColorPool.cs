using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[CreateAssetMenu]
public class ColorPool : ScriptableObject
{
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;
    public Color color6;
    public Color color7;
    public Color color8;
    public static int curIndex = 0;

    public Color PickColor()
    {
        Color ret;
        switch (curIndex)
        {
            case 0:
                ret = color1;
                break;
            case 1:
                ret = color2;
                break;
            case 2:
                ret = color3;
                break;
            case 3:
                ret = color4;
                break;
            case 4:
                ret = color5;
                break;
            case 5:
                ret = color6;
                break;
            case 6:
                ret = color7;
                break;
            case 7:
                ret = color8;
                break;
            default:
                ret = Color.clear;
                break;
        }
        curIndex++;
        return ret;
    }
}
