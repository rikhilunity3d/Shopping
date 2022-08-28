using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(EventListener))]
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

        /*GameEventHub.Print(this.GetType(), "OnMouseUp");
        //Enable Collider of All Counters GameObjects.
        var temp1 = GameEventHub.listOfCounters;
        for (int i = 0; i < temp1.Count; i++)
        {
            temp1[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        //Disable Collider of All counters except on which it is clicked;
        var temp2 = GameEventHub.listOfClickedCounters;
        
        for (int i = 0; i < temp2.Count; i++)
        {
            if (temp1.Contains(temp2[i].gameObject))
            {
                int index = temp1.IndexOf(temp2[i].gameObject);
                temp1[index].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }*/
    }

    private void DisableBoxColliderOnGameObjects()
    {
        // Added clicked Display Item here and we will use below list to disable
        // collider of clicked Items in ItemClickHandler script.
        GameEventHub.listOfClickedCounters.Add(GameEventHub.go);

        for (int i = 0; i < GameEventHub.listOfCounters.Count; i++)
        {
            GameEventHub.listOfCounters[i].GetComponent<BoxCollider2D>().enabled = false;
            GameEventHub.Print(this.GetType(), " Disabling BoxCollider2D on " + GameEventHub.listOfCounters[i].name);
        }
    }
}

