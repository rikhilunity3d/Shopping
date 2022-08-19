using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Listen to Mouse Down Event of its Inner Item like a t-shirt of Top
    // Collection Hanger, like a hat of Hat Collection, etc.
    public void WindowClose()
    {
        GameEventHub.Print(this.GetType(), "Window Close Function Call");
        // Animation Out
    }
}
