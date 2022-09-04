using System.Collections.Generic;
using UnityEngine;

public class Choclates : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    Sprite levelBackground;
    [SerializeField]
    SpriteRenderer ChocolateHolder;
    [SerializeField]
    int noOfChoice;
    [SerializeField]
    [Range(1, 10)]
    int MaximumQuantityToBuy;
    [SerializeField]
    List<GameObject> AnimationPathPoints;
    [SerializeField]
    DepartmentChocolate departmentChocolate;
    [SerializeField]
    List<GameObject> ChocolateCompartment;
    #endregion

    #region Non - SerializeFields
    List<int> _chocolatesIndex;
    List<ItemChocolate> _chocolatesToBuy;
    #endregion

    #region Game Events
    public GameEvent EventDisplayQuantity;
    public GameEvent EventSetTargetItem;
    public GameEvent EventJarInAnimation;
    public GameEvent EventJarLidInAnimation;
    public GameEvent EventJarOutAnimation;
    public GameEvent EventLevelComplete;
    #endregion

    
    private void OnEnable()
    {
        _chocolatesIndex = GetIndexsForChoice(noOfChoice);

        _chocolatesToBuy = GetChocolatesFromIndex(_chocolatesIndex);

        AsignRandomQuantityToBuy(_chocolatesToBuy);
    }
    private void Start()
    {
        SetAnimationPathPoints(AnimationPathPoints);
        EventSetTargetItem.Raise();
        
        print(this.GetType().Name + " On Start");
    }

    private void SetAnimationPathPoints(List<GameObject> animationPathPoints)
    {
        for (int i = 0; i < animationPathPoints.Count; i++)
        {
            print("Animation Path Points " + animationPathPoints[i]);
            GameEventHub.animationPathPoints.Add(animationPathPoints[i]);
        }

    }

    public void SetTargetItem()
    {
        print(this.GetType().Name + " Set Target Item");

        print(this.GetType().Name+" IndexForItem " + GameEventHub.indexForItem + " ItemQuantity "+ _chocolatesToBuy.Count);
        if (GameEventHub.indexForItem < _chocolatesToBuy.Count)
        {
            ChocolateHolder.GetComponent<SpriteRenderer>().sprite = _chocolatesToBuy[GameEventHub.indexForItem].itemSprite;
            // Data Set in Event Hub
            GameEventHub.itemCount = _chocolatesToBuy[GameEventHub.indexForItem].buyQuantity;
            GameEventHub.go = ChocolateCompartment[_chocolatesIndex[GameEventHub.indexForItem]].gameObject;
            GameEventHub.go.GetComponent<BoxCollider2D>().enabled = true;
            GameEventHub.go.GetComponent<EventListener>().enabled = true;
            // Event Raise to set quantity of items. This quantity will be displayed at character chat box.
            EventDisplayQuantity.Raise();
            EventJarInAnimation.Raise();
        }
        else
        {
            GameEventHub.indexForItem = 0;
            EventLevelComplete.Raise();
        }
        
    }
    
    public void LevelCompleted()
    {
        print(this.GetType().Name + " Level is now Completed");
        //EventJarOutAnimation.Raise();
        EventJarLidInAnimation.Raise();
        gameObject.SetActive(false);
        //Enable Shop GameObject
        UIManager.Instance.EnableNextButton(true);
    }

    
    private void AsignRandomQuantityToBuy(List<ItemChocolate> chocolatesToBuy)
    {
        for (int i =0;i< chocolatesToBuy.Count;i++)
        {
            int temp = UnityEngine.Random.Range(1, MaximumQuantityToBuy);
            chocolatesToBuy[i].buyQuantity = temp;
        }
        PrintData(chocolatesToBuy);
    }

    private List<int> GetIndexsForChoice(int noOfChoice)
    {
        List<int> _listIndex = new List<int>(noOfChoice);
        print(this.GetType().Name + " no Of Choice "+noOfChoice);
        for(int i =0;i< noOfChoice || _listIndex.Count < noOfChoice; i++)
        {
            int temp = UnityEngine.Random.Range(0, departmentChocolate.ListOfChocoloates.Count - 1);
            if (!_listIndex.Contains(temp))
            {
                _listIndex.Add(temp);
//                print(this.GetType().Name + " index " + temp);
            }
        }
        return _listIndex;
    }

    private List<ItemChocolate> GetChocolatesFromIndex(List<int> _chocolatesIndex)
    {
        List<ItemChocolate> _chocolatesToBuy = new List<ItemChocolate>();
        for (int i = 0; i < _chocolatesIndex.Count; i++)
        {
            
            int j = _chocolatesIndex[i];
            _chocolatesToBuy.Add(departmentChocolate.ListOfChocoloates[j]);
            // enabling collider of chocolate compartment according to the _chocolatesIndex array
            //ChocolateCompartment[j].GetComponent<BoxCollider2D>().enabled = true;

        }
        return _chocolatesToBuy;
    }

    void PrintData(List<ItemChocolate> data)
    {
        for(int i=0;i< data.Count;i++)
        {
            string itemName = data[i].itemName;
            Sprite itemSprite = data[i].itemSprite;
            int itemPrice = data[i].itemPrice;
            int itemBuyQuantity = data[i].buyQuantity;
            print(this.GetType().Name + " Choice of " + itemName + " Quantity is " + itemBuyQuantity + " | Price is " + itemPrice + " | " + itemSprite.name);
        }
    }
    


    [System.Serializable]
    class DepartmentChocolate
    {
        [SerializeField]
        string departmentName;
        [SerializeField]
        List<ItemChocolate> listOfChocoloates;
        public List<ItemChocolate> ListOfChocoloates { get => listOfChocoloates; set => listOfChocoloates = value; }
    }

    [System.Serializable]
    class ItemChocolate // Afterwards rename Item Class with generic type where type will be chocolate or other
    {
        public Sprite itemSprite;
        public string itemName;
        public int itemPrice;
        public int buyQuantity=0;
    }
}
