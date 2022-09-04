using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(EventListener))]
[RequireComponent(typeof(ShakeAnimation))]
public class CounterClickHandler : MonoBehaviour
{
    [SerializeField]
    GameEvent EventClickedOnCounter;
    private void OnMouseDown()
    {
        GameEventHub.currentClickCounter = this.gameObject;
        GameEventHub.Print(this.GetType(), this.gameObject.name);
        this.gameObject.GetComponent<EventListener>().enabled = true;
        this.EventClickedOnCounter.Raise();        
    }

    private void OnMouseUp()
    {
        DisableBoxColliderOnGameObjects();
        DisableShopGameObject();
    }

    private void DisableBoxColliderOnGameObjects()
    {
        // Added clicked Display Item here and we will use below list to disable
        // collider of clicked Items in CounterClickHandler script.

        for (int i = 0; i < GameEventHub.CountersExceptCashCounter.Count; i++)
        {
            GameEventHub.CountersExceptCashCounter[i].GetComponent<BoxCollider2D>().enabled = false;
            GameEventHub.Print(this.GetType(), " Disabling BoxCollider2D on " + GameEventHub.CountersExceptCashCounter[i].name);
        }
    }

    private void DisableShopGameObject()
    {
        GameEventHub.GOShop.SetActive(false);
    }
}

