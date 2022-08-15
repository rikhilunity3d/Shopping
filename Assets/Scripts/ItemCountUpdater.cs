using UnityEngine;
using TMPro;

public class ItemCountUpdater : MonoBehaviour
{
 
    TextMeshProUGUI _text;
    [SerializeField]
    GameEvent SetTargetItemEvent;
    // Listener
    public void DecrementItemCount()
    {
        GameEventHub.itemCount--;
        if(GameEventHub.itemCount <= 0)
        {
            GameEventHub.itemCount = 0;
            GameEventHub.go.GetComponent<BoxCollider2D>().enabled = false;
            GameEventHub.indexForItem++;
            SetTargetItemEvent.Raise();
        }
        print(this.GetType().Name + " Remaining Items after Updates " + GameEventHub.itemCount);
        _text.text = GameEventHub.itemCount.ToString();
    }
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = GameEventHub.itemCount.ToString();
        print(this.GetType().Name + " Remaining Items " + GameEventHub.itemCount);
    }

}
