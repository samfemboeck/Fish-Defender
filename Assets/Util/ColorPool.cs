using System.Collections.Generic;
using UnityEngine;

/*
 * Used by PlayerInput.cs
 */
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
    private Stack<Color> colors = new Stack<Color>();

    private void OnEnable()
    {
        // push colors backwards since a Stack is Last-In-First-Out
        colors.Push(color8);
        colors.Push(color7);
        colors.Push(color6);
        colors.Push(color5);
        colors.Push(color4);
        colors.Push(color3);
        colors.Push(color2);
        colors.Push(color1);
    }

    public Color Get()
    {
        return colors.Pop();
    }

    public void Return(Color color)
    {
        colors.Push(color);
    }
}
