using UnityEngine;

public static class Extensions
{
    public static void Fade(this SpriteRenderer sr, float alpha)
    {
        var color = sr.color;
        color.a = alpha;
        sr.color = color;
    }
}
