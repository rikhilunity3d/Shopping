using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choclates : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    Sprite levelBackground;
    [SerializeField]
    Sprite standBackground;
    [SerializeField]
    SpriteRenderer ChocolateHolder;
    [SerializeField]
    int noOfChoice;
    [SerializeField]
    List<Transform> movePoints;
    [SerializeField]
    DepartmentChocolate departmentChocolate;
    [SerializeField]
    List<GameObject> ChocolateCompartment;
    [SerializeField]
    List<GameObject> ChocolateSinglePrefab;
    #endregion

    List<int> _chocolatesIndex;
    List<ItemChocolate> _chocolatesToBuy;
    Transform _nextPos;
    int nextPosIndex=0;

    
    public GameEvent EventDisplayQuantity;
    public GameEvent EventSetTargetItem;
    public GameEvent EventJarInAnimation;
    public GameEvent EventLevelComplete;

    private void Awake()
    {
        SetCameraOrthographicSize();

        _chocolatesIndex = GetIndexsForChoice(noOfChoice);

        _chocolatesToBuy = GetChocolatesFromIndex(_chocolatesIndex);
        
        AsignRandomQuantityToBuy(_chocolatesToBuy);
    }
    private void OnEnable()
    {

        
    }
    private void Start()
    {
        EventSetTargetItem.Raise();
        print(this.GetType().Name + " On Start");
    }

    public void SetTargetItem()
    {
        print(this.GetType().Name + " Set Target Item");

        print(this.GetType().Name+" " + GameEventHub.indexForItem + " "+ _chocolatesToBuy.Count);
        if (GameEventHub.indexForItem < _chocolatesToBuy.Count)
        {
            ChocolateHolder.GetComponent<SpriteRenderer>().sprite = _chocolatesToBuy[GameEventHub.indexForItem].itemSprite;
            // Data Set in Event Hub
            GameEventHub.itemCount = _chocolatesToBuy[GameEventHub.indexForItem].buyQuantity;
            GameEventHub.go = ChocolateCompartment[_chocolatesIndex[GameEventHub.indexForItem]].gameObject;
            GameEventHub.go.GetComponent<BoxCollider2D>().enabled = true;
            // Event Raise to set quantity of items. This quantity will be displayed at character chat box.
            EventDisplayQuantity.Raise();
            //EventJarInAnimation.Raise();
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
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0.0f;
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

            if (hit && hit.collider != null)
            {
                print(hit.transform.gameObject.name);
                GameObject gameObject = new GameObject();
                gameObject.AddComponent<SpriteRenderer>().sprite = _chocolatesToBuy[0].itemSprite;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 300;
                gameObject.transform.position = pos;
                
                //Instantiate(gameObject, pos, gameObject.transform.rotation);
                _nextPos = movePoints[0];
                MoveGameObject(gameObject.transform);
                

            }
        }
    }

    void MoveGameObject(Transform transform)
    {
        while(true)
        {
            print(transform.position);
            if (transform.position == _nextPos.position)
            {
                nextPosIndex++;
                if (nextPosIndex >= movePoints.Count)
                {
                    nextPosIndex = 0;
                    break;
                }
                //_nextPos = movePoints[nextPosIndex];
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, _nextPos.position, 1 * Time.deltaTime);
                print("After");
                print(_nextPos.position);
                print(transform.position);
            }
        }
        
    }
    private void AsignRandomQuantityToBuy(List<ItemChocolate> chocolatesToBuy)
    {
        for (int i =0;i< chocolatesToBuy.Count;i++)
        {
            int temp = UnityEngine.Random.Range(1, 8);
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
    
    void SetCameraOrthographicSize()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = levelBackground.bounds.size.x / levelBackground.bounds.size.y;
        float differenceInSize = targetRatio / screenRatio;
        Camera.main.orthographicSize = levelBackground.bounds.size.y / 2 * differenceInSize;
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
