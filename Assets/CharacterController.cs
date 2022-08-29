using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent (typeof(EventListener))]
public class CharacterController : MonoBehaviour
{
    [SerializeField]
    GameEvent EventSliderOpenOrClose;

    [SerializeField]
    GameEvent EventElementShake;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ShakeAnimation>())
        {
            GameEventHub.Print(GetType(), " Collide with " + collision.gameObject.name);
            collision.gameObject.GetComponent<EventListener>().enabled = true;
            EventElementShake.Raise();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEventHub.Print(GetType(), " OnTriggerExit2D " + collision.gameObject.name);
        collision.gameObject.GetComponent<EventListener>().enabled = false;
    }

    public void ScaleAnimation()
    {
        GameEventHub.Print(this.GetType(), "ScaleAnimation() Listener of " + GetComponent<EventListener>().Event);
        this.gameObject.transform.DOScale(1f, 1.5f).OnComplete(ScaleAnimationComplete);
    }

    void ScaleAnimationComplete()
    {
        GameEventHub.Print(this.GetType(), "ScaleAnimationComplete() -> EventSliderOpenOrClose Raised");
        
        EventSliderOpenOrClose.Raise();

    }
}
