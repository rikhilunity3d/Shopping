using UnityEngine;
using TMPro;

public class ItemCountUpdater : MonoBehaviour
{
    TMP_Text _text;
    [SerializeField]
    GameEvent EventSetTargetItem;
    // Listener
    public void DecrementItemQuantity()
    {
        GameEventHub.itemCount--;
        GameEventHub.Print(this.GetType(), " Decrement Item Quantity " + GameEventHub.itemCount);
        _text.text = GameEventHub.itemCount.ToString();
        if (GameEventHub.itemCount <=0)
        {
            GameEventHub.go.GetComponent<EventListener>().enabled = false;
            GameEventHub.go.GetComponent<BoxCollider2D>().enabled = false;
            GameEventHub.indexForItem++;
            EventSetTargetItem.Raise();
        }
    }

    private void Start()
    {
        DisplayQuanitiy();
    }

    public void DisplayQuanitiy()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = GameEventHub.itemCount.ToString();
        GameEventHub.Print(this.GetType()," Display Quanitiy " + GameEventHub.itemCount);
        
    }

}
