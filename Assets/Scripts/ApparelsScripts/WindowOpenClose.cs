using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EventListener))]
public class WindowOpenClose : MonoBehaviour
{
    // Listen to Mouse Down Event of Group of Items like Top Collection Hanger,
    // like Hat Collection, like Shoes Collection, etc.
    public void WindowOpen()
    {
        GameEventHub.Print(this.GetType(), "Window Open Function Call");
        // Animation In
        GameEventHub.Print(this.GetType(), " Window Open Animation");
        this.transform.DOMove(new Vector3(4.5f, 0f, 0), 2f)
        .SetEase(Ease.OutQuad);

        // Enable child game object according to the id of DisplayTop, Display
        // Bottom, DisplayHat, etc.
        Transform temp = this.gameObject.transform;
        if(temp.childCount > 0)
        {
            temp.GetChild(GameEventHub.id - 1).gameObject.SetActive(true);
        }
    }

    // Listen to Mouse Down Event of its Inner Item like a t-shirt of Top
    // Collection Hanger, like a hat of Hat Collection, etc.
    public void WindowClose()
    {
        GameEventHub.Print(this.GetType(), "Window Close Function Call");
        // Animation Out
        GameEventHub.Print(this.GetType()," Window Close Animation");
        this.transform.DOMove(new Vector3(20f, 0f, 0), 2f)
        .SetEase(Ease.OutQuad);

        // Disable child game object according to the id of DisplayTop, Display
        Transform temp = this.gameObject.transform;
        if (temp.childCount > 0)
        {
            temp.GetChild(GameEventHub.id - 1).gameObject.SetActive(false);
        }
    }
}
