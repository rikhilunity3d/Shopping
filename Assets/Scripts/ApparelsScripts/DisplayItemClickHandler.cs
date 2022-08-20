using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DisplayItemClickHandler : MonoBehaviour
{
    [SerializeField]
    GameEvent EventWindowOpen;
    [SerializeField]
    int id;
    private void OnMouseDown()
    {
        GameEventHub.Print(this.GetType(), " OnMouseDown");

        GameEventHub.go = this.gameObject;
        GameEventHub.id = this.id;
        GameEventHub.Print(this.GetType(), "Click on "+ GameEventHub.go.name+" and id is "+ GameEventHub.id);
        
        this.EventWindowOpen.Raise();
        GameEventHub.Print(this.GetType(), GameEventHub.go.name + " EventWindowOpen Raised");
    }
    private void OnMouseUp()
    {
        GameEventHub.Print(this.GetType(), " OnMouseUp");
        DisableBoxColliderOnGameObjects();
    }

    private void DisableBoxColliderOnGameObjects()
    {
        for (int i = 0; i < GameEventHub.listOfGameObject.Count; i++)
        {
            GameEventHub.listOfGameObject[i].GetComponent<BoxCollider2D>().enabled = false;
            GameEventHub.Print(this.GetType(), " Disabling BoxCollider2D on " + GameEventHub.listOfGameObject[i].name);
        }
    }
}
