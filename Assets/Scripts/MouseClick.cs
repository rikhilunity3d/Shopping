using UnityEngine;
using DG.Tweening;

public class MouseClick : MonoBehaviour
{
    PathType pathType = PathType.CatmullRom;
    public GameEvent EventItemPicked;
    public GameEvent EventDecrementItemQuantity;
    GameObject childGO;

    private void OnMouseDown()
    {
        GameEventHub.Print(this.GetType()," OnMouseDown");
        GameEventHub.Print(this.GetType() , GameEventHub.go.name + " Event Raised");
        this.EventItemPicked.Raise();
    }

    private void OnMouseUp()
    {
        GameEventHub.Print(this.GetType(), " OnMouseUp");
        EventDecrementItemQuantity.Raise();   
    }
    public void MoveGameObjectAnimation()
    {

        this.childGO = GameEventHub.go.transform.GetChild(GameEventHub.itemCount).gameObject;

        this.childGO.transform.DOPath(GameEventHub.GetAnimationPathPoints(), GameEventHub.animationPathPoints.Count, this.pathType)
            .SetEase(Ease.OutQuad)
            .SetSpeedBased(true)
            .OnComplete(OnCompleteAnimation);

    }

    void OnCompleteAnimation()
    {
        this.childGO.transform.parent = GameEventHub.GOJarBack.transform;
        
        
    }
}
