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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
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
