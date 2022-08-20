using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    [SerializeField]
    GameEvent EventWindowClose;
    private void OnMouseDown()
    {
        GameEventHub.Print(this.GetType(), this.gameObject.name);

        //

        
    }
    private void OnMouseUp()
    {
        GameEventHub.Print(this.GetType(), "OnMouseUp EventWindowClose");
        // Close the Window
        EventWindowClose.Raise();
    }
}
