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
        if(GameEventHub.itemCount <= 0)
        {
            GameEventHub.itemCount = 0;
            GameEventHub.go.GetComponent<BoxCollider2D>().enabled = false;
            GameEventHub.indexForItem++;
            EventSetTargetItem.Raise();
        }
        print(this.GetType().Name + " Decrement Item Quantity " + GameEventHub.itemCount);
        _text.text = GameEventHub.itemCount.ToString();
    }
    private void Start()
    {
        DisplayQuanitiy();
    }

    public void DisplayQuanitiy()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = GameEventHub.itemCount.ToString();
        print(this.GetType().Name + " Display Quanitiy " + GameEventHub.itemCount);
    }

}
