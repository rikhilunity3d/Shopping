using UnityEngine;

[RequireComponent(typeof(EventListener))]
public class OpenCloseRespectiveCounter : MonoBehaviour
{
    public void EnableRespectiveCounter()
    {
        GameEventHub.Print(GetType(), "Enable Respective Counter");
        //transform.GetChild(GameEventHub.currentClickCounter.transform.GetSiblingIndex()).gameObject.SetActive(true);

        GameEventHub.Print(GetType(), transform.GetChild(GameEventHub.currentClickCounter.transform.GetSiblingIndex()).gameObject.name);

        if (transform.GetChild(GameEventHub.currentClickCounter.transform.GetSiblingIndex()).gameObject.activeInHierarchy)
        {
            transform.GetChild(GameEventHub.currentClickCounter.transform.GetSiblingIndex()).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(GameEventHub.currentClickCounter.transform.GetSiblingIndex()).gameObject.SetActive(true);
        }
        
    }
}
 