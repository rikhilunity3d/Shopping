using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EventListener))]
[RequireComponent(typeof(EventListener))]
public class GetAllCounters : MonoBehaviour
{
    Transform temp;
    private void Awake()
    {
        temp = this.gameObject.transform;
        GameEventHub.Print(this.GetType(), " OnAwake");
        if (temp.childCount > 0)
        {
            for (int i = 0; i < temp.childCount-1; i++)
            {
                if (temp.GetChild(i).GetComponent<ShakeAnimation>())
                {
                    GameEventHub.CountersExceptCashCounter.Add(temp.GetChild(i).gameObject);
                    GameEventHub.Print(this.GetType(), " Adding " +
                    temp.GetChild(i).gameObject.name + " to " + "GameEventHub.listOfCounters");
                }
            }
        }
    }

    public void EnableCashCounter()
    {
        GameEventHub.Print(GetType(), " Listner Enable Cash Counter");
            //Enable Billing Counter Here
            temp.GetChild(temp.childCount-1).GetComponent<BoxCollider2D>().enabled = true;
        
    }
    public void OpenCounter()
    {
        
        if(GameEventHub.currentClickCounter!=null && temp!=null)
        {
            if(GameEventHub.currentClickCounter.transform.IsChildOf(temp))
            {
                GameEventHub.Print(GetType()," Sibling Index is "+GameEventHub.currentClickCounter.transform.GetSiblingIndex().ToString());
                GameEventHub.Print(GetType(), " OpenCounter");
                
                
            }
        }
    }
}
