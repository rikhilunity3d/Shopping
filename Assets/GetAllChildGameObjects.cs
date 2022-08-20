using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllChildGameObjects : MonoBehaviour
{
    private void Awake()
    {
        GameEventHub.Print(this.GetType(), " OnAwake");
        var temp = this.gameObject.transform;
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
}
