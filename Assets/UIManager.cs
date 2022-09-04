using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class UIManager : GenericSingleton<UIManager>
{

    [SerializeField]
    GameEvent EventClickedOnCounter;
    [SerializeField]
    GameEvent EventEnableCashCounter;
    [SerializeField]
    List<GameObject> list = new List<GameObject>();

    [SerializeField]
    Button BtnNext;

    public void EnablePanelWithName(PanelName panelName)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(list[i].name.Equals(panelName.ToString()));
        }
    }

    public void DisablePanelWithName(PanelName panelName)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(!list[i].name.Equals(panelName.ToString()));
        }
    }

    public void EnableNextButton(bool b)
    {
        BtnNext.gameObject.SetActive(b);
    }

    public void HandleNextButtonClick()
    {
        EnableNextButton(false);
        GameEventHub.GOShop.SetActive(true);
        EnableBoxColliderOnGameObjects();
        EventClickedOnCounter.Raise();
        
    }

    public void EnableBoxColliderOnGameObjects()
    {
        for (int i = 0; i < GameEventHub.CountersExceptCashCounter.Count; i++)
        {
            GameEventHub.CountersExceptCashCounter[i].GetComponent<BoxCollider2D>().enabled = true;
            GameEventHub.Print(this.GetType(), " Enable BoxCollider2D on " + GameEventHub.CountersExceptCashCounter[i].name + " Counters");
        }
        AddVisitedCounterToListOfClickedCounters();
    }



    void AddVisitedCounterToListOfClickedCounters()
    {
        if (!GameEventHub.VisitedCountersExceptCashCounter.Contains(GameEventHub.currentClickCounter))
        {
            GameEventHub.VisitedCountersExceptCashCounter.Add(GameEventHub.currentClickCounter);
            EnableDoneSign();
        }
        DisableColliderOfVisitedCounter();
    }

    private void EnableDoneSign()
    {
        GameEventHub.currentClickCounter.transform.GetChild(0).gameObject.SetActive(true);
    }

    void DisableColliderOfVisitedCounter()
    {
        for(int i=0;i<GameEventHub.VisitedCountersExceptCashCounter.Count;i++)
        {
            GameEventHub.VisitedCountersExceptCashCounter[i].GetComponent<BoxCollider2D>().enabled = false;
            GameEventHub.VisitedCountersExceptCashCounter[i].GetComponent<EventListener>().enabled = false;

        }
        CheckToEnableCashCounter();
    }

    void CheckToEnableCashCounter()
    {
        GameEventHub.Print(GetType(), "CheckToEnableCashCounter" + GameEventHub.VisitedCountersExceptCashCounter.Count + " " + (GameEventHub.CountersExceptCashCounter.Count));

        if (GameEventHub.VisitedCountersExceptCashCounter.Count == GameEventHub.CountersExceptCashCounter.Count)
        {
            //Enable Billing Counter Here
            GameEventHub.Print(GetType(), " Enable Cash Counter");
            EventEnableCashCounter.Raise();
        }
    }
    
}
