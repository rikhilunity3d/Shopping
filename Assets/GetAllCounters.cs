using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            for (int i = 0; i < temp.childCount; i++)
            {
                if (temp.GetChild(i).GetComponent<ShakeAnimation>())
                {
                    GameEventHub.listOfCounters.Add(temp.GetChild(i).gameObject);
                    GameEventHub.Print(this.GetType(), " Adding " +
                    temp.GetChild(i).gameObject.name + " to " + "GameEventHub.listOfCounters");
                }
            }
        }
    }

    public void OpenCounter()
    {
        
        if(GameEventHub.currentClickCounter!=null && temp!=null)
        {
            if(GameEventHub.currentClickCounter.transform.IsChildOf(temp))
            {
                GameEventHub.Print(this.GetType(), " OpenCounter");
                GameEventHub.currentClickCounter.SetActive(false);
            }
        }
    }
}
