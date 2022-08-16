using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseClick : MonoBehaviour
{
    PathType pathType = PathType.CatmullRom;
    public GameEvent EventItemPicked;
    GameObject childGO;

    private void OnMouseDown()
    {
        GameEventHub.go = this.gameObject;
        EventItemPicked.Raise();
        print(this.GetType().Name +" "+ this.gameObject.name + " Event Raised");
    }

    
    public void MoveGameObjectAnimation()
    {

        //GameEventHub.pathArray[0] = this.gameObject.transform.position;

        GameEventHub.pathArray.Add(GameEventHub.GOJarBack.transform.position);

        print(this.gameObject.transform.position + " " + GameEventHub.GOJarBack.transform.position + " " + GameEventHub.pathArray.Count);

        childGO= GameEventHub.go.transform.GetChild(GameEventHub.indexForItem).gameObject;

        childGO.transform.DOPath(GameEventHub.pathArray.ToArray(), GameEventHub.pathArray.Count, pathType)
            .SetEase(Ease.OutQuad)
            .OnComplete(OnCompleteAnimation);

    }

    void OnCompleteAnimation()
    {
        childGO.transform.parent = GameEventHub.GOJarBack.transform;
        print(this.GetType().FullName + " Play Move GameObject Animation");
            //GameEventHub.GOJarBack 
        GameEventHub.pathArray.Clear();
    }
}
