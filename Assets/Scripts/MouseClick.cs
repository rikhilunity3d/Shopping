using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public GameEvent EventItemPicked;
    private void OnMouseDown()
    {
        EventItemPicked.Raise();
    }
}
