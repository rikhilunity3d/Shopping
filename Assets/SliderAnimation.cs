using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EventListener))]
public class SliderAnimation : MonoBehaviour
{ 
    [Header("Note: EventSliderOpenOrClose Drag N Drop in EventListener Script not Below")]
    [Tooltip("EventCharacterEntry Drag N Drop")] 
    [SerializeField]
    GameEvent EventCharacterEntry;
    Vector3 startPosition;
    [SerializeField]
    Vector3 endPosition;
    [SerializeField]
    bool isOpen=false;
    

    private void Start()
    {
        startPosition = this.gameObject.transform.localPosition;
        SliderOpenOrCloseAnimation();
    }

    public void SliderOpenOrCloseAnimation()
    {
        print(this.GetType().FullName + " SliderOpenAnimation() ");
        if(!isOpen)
        {
            CharacterEntry();
            this.transform.DOLocalMove(endPosition, 2.5f)
            .SetEase(Ease.OutQuad)
            .OnComplete(SliderOpen);

        }
        else
        {
            this.transform.DOLocalMove(startPosition, 2.5f)
            .SetEase(Ease.OutQuad)
            .OnComplete(SliderClose);
        }
        // Vector3(-22.6399994,4.26000023,0)
        // Vector3(-19.4599991, 4.26000023, 0)
    }

    void SliderOpen()
    {
        GameEventHub.Print(this.GetType(), " SliderOpen()");
        isOpen = true;
    }

    void SliderClose()
    {
        GameEventHub.Print(this.GetType(), " SliderClose()");
        isOpen = false;
    }

    void CharacterEntry()
    {
        GameEventHub.Print(this.GetType(), " CharacterEntry()");

        EventCharacterEntry.Raise();
    }
}


