using UnityEngine;

public class DisplayItemClickHandler : MonoBehaviour
{
    [SerializeField]
    GameEvent EventWindowOpen;
    private void OnMouseDown()
    {
        GameEventHub.Print(this.GetType(), " OnMouseDown");

        GameEventHub.go = this.gameObject;
        GameEventHub.Print(this.GetType(), "Click on "+ GameEventHub.go.name);
        
        this.EventWindowOpen.Raise();
        GameEventHub.Print(this.GetType(), GameEventHub.go.name + " EventWindowOpen Raised");
    }
}
