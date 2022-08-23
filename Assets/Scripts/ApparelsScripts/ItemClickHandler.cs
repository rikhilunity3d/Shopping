using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    [SerializeField]
    GameEvent EventWindowClose;
    [SerializeField]
    GameEvent EventItemPicked;
    [SerializeField]
    List<GameObject> AnimationPathPoints;

    PathType pathType = PathType.CatmullRom;

    private void Awake()
    {
        SetAnimationPathPoints(AnimationPathPoints);
    }

    private void OnMouseDown()
    {
        GameEventHub.Print(this.GetType(), this.gameObject.name);
        this.gameObject.GetComponent<EventListener>().enabled = true;
        this.EventItemPicked.Raise();
        //this.OnMouseUp();
    }

    private void OnMouseUp()
    {
        GameEventHub.Print(this.GetType(), "OnMouseUp EventWindowClose");
        //Enable Collider of All DisplayItems GameObjects.
        var temp1 =GameEventHub.listOfGameObject;
        for (int i=0;i< temp1.Count;i++)
        {
            temp1[i].gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        //Disable Collider of All GameObjects except on which it is clicked;
        var temp2 = GameEventHub.listOfClickedGameObject;
        for (int i=0;i< temp2.Count;i++)
        {
            if (temp1.Contains(temp2[i].gameObject))
            {
                int index = temp1.IndexOf(temp2[i].gameObject);
                temp1[index].gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }


    public void MoveGameObjectAnimation()
    {
        if(GameEventHub.animationPathPoints.Count>0)
        {
            this.gameObject.transform.DOPath(GameEventHub.GetAnimationPathPoints(),
                GameEventHub.animationPathPoints.Count,
                this.pathType,PathMode.TopDown2D)
            .SetEase(Ease.OutQuad)
            .SetSpeedBased(true)
            .OnComplete(OnCompleteAnimation);
        }
        else
        {
            GameEventHub.Print(this.GetType(), " Add Animation Path Points to -> AnimationPathPoints GameObject");
        }
    }

    void OnCompleteAnimation()
    {
        // Close the Window
        this.EventWindowClose.Raise();

        this.gameObject.transform.parent = GameEventHub.GOJarBack.transform;
        this.gameObject.GetComponent<EventListener>().enabled = false;
    }    

    private void SetAnimationPathPoints(List<GameObject> animationPathPoints)
    {
        for (int i = 0; i < animationPathPoints.Count; i++)
        {
            GameEventHub.Print(this.GetType(), "Animation Path Points " + animationPathPoints[i]);
            GameEventHub.animationPathPoints.Add(animationPathPoints[i]);
        }

    }
}
