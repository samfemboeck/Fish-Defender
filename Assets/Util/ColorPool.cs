using UnityEngine;

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
        Color[] colors = new Color[] { color1, color2, color3, color4, color5, color6, color7, color8 };
        return colors[curIndex++];
    }
}
