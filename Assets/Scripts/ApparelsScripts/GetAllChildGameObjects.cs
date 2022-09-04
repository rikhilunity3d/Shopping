using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class GetAllChildGameObjects : MonoBehaviour
{
    [SerializeField]
    GameEvent EventJarInAnimation;
    private void Awake()
    {
        GameEventHub.Print(this.GetType(), " OnAwake");
        var temp = this.gameObject.transform;
        GameEventHub.listOfGameObject.Clear();
        GameEventHub.listOfClickedGameObject.Clear();
        if (temp.childCount > 0 )
        {
            for (int i=0;i< temp.childCount;i++)
            {
                if (temp.GetChild(i).GetComponent<DisplayItemClickHandler>())
                {
                    GameEventHub.listOfGameObject.Add(temp.GetChild(i).gameObject);
                    GameEventHub.Print(this.GetType(), " Adding "+
                    temp.GetChild(i).gameObject.name +" to "+ "GameEventHub.listOfGameObject");
                }   
            }   
        }
    }

    private void Start()
    {
        EventJarInAnimation.Raise();
    }
}
