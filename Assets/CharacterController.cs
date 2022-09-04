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

    private void Start()
    {
        GameEventHub.GOShop = GetComponentInParent<SetCameraOrthographicSizeAccordingToBackground>().gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out ShakeAnimation shakeAnimation))
        {
            if(shakeAnimation.TryGetComponent(out EventListener ev))
            {
                ev.enabled = true;
            }
            EventElementShake.Raise();
        }

        if(collision.TryGetComponent(out CartClickHandler cartClickHandler))
        {
            gameObject.GetSiblingWithDesireComponent
                <SetCameraOrthographicSizeAccordingToBackground,
                ParallaxBackgroundController>();
        }

        if(collision.TryGetComponent(out ShoppingList shoppingList))
        {
            shoppingList.EnableShoppingListPanel();

            if (shoppingList.TryGetComponent(out BoxCollider2D boxCollider2D))
                boxCollider2D.enabled = false;
            
            gameObject.GetSiblingWithDesireComponent
                <SetCameraOrthographicSizeAccordingToBackground,
                ParallaxBackgroundController>();
        }   
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEventHub.Print(GetType(), " OnTriggerExit2D " + collision.gameObject.name);

        if(collision.gameObject.GetComponent<EventListener>())
            collision.gameObject.GetComponent<EventListener>().enabled = false;

        if (collision.gameObject.TryGetComponent(out SpriteRenderer sp))
        {
            sp.Fade(0.70f);
        }
        
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
