using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class UIManager : GenericSingleton<UIManager>
{

    [SerializeField]
    GameEvent EventClickedOnCounter;
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
        if (!GameEventHub.listOfClickedCounters.Contains(GameEventHub.currentClickCounter))
        {
            GameEventHub.listOfClickedCounters.Add(GameEventHub.go);
        }
        GameEventHub.GOShop.SetActive(true);
        EventClickedOnCounter.Raise();
    }
}
