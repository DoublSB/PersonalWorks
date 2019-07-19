using System;
using System.Drawing;

public class ColorPalette
{
    private Color[] Colors = new Color[10];
    
    public enum Color_
    {
        Gray,
        Cyan,
        Rhyme,
        CheeryPink,
        Pink
    }

    public ColorPalette()
    {
        for (int i = 0; i < Colors.Length; i++)
        {
            Colors[i] = new Color();
        }

        Colors[0] = Color.FromArgb(85, 98, 112);
        Colors[1] = Color.FromArgb(78, 205, 196);
        Colors[2] = Color.FromArgb(199, 244, 100);
        Colors[3] = Color.FromArgb(255, 107, 107);
        Colors[4] = Color.FromArgb(196, 77, 88);
    }

    public Color Get(Color_ name)
    {
        switch (name)
        {
            case Color_.Gray:
                return Colors[0];
            case Color_.Cyan:
                return Colors[1];
            case Color_.Rhyme:
                return Colors[2];
            case Color_.CheeryPink:
                return Colors[3];
            case Color_.Pink:
                return Colors[4];
            default:
                return Color.White;
        }
    }

}
