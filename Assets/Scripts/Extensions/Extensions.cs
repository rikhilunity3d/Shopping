using UnityEngine;

public static class Extensions
{
    public static void Fade(this SpriteRenderer sr, float alpha)
    {
        var color = sr.color;
        color.a = alpha;
        sr.color = color;
    }

    public static void GetSiblingWithDesireComponent<P, C>(this GameObject go) where P : MonoBehaviour where C : MonoBehaviour
    {
        if (go.GetComponentInParent<P>())
        {
            GameEventHub.Print(go.GetType(), "GetSiblingWithDesireComponent ");
            go.GetComponentInParent<P>().GetComponentInChildren<C>().enabled = true;
        }
    }
}
