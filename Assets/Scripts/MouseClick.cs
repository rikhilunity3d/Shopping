using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public GameEvent ItemPickedEvent;
    private void OnMouseDown()
    {
        ItemPickedEvent.Raise();
    }
}
