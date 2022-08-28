using UnityEngine;

[RequireComponent(typeof(EventListener))]
public class OpenCloseRespectiveCounter : MonoBehaviour
{
    public void EnableRespectiveCounter()
    {
        GameEventHub.Print(GetType(), "Enable Respective Counter");
        transform.GetChild(GameEventHub.currentClickCounter.transform.GetSiblingIndex()).gameObject.SetActive(true);
    }
}
