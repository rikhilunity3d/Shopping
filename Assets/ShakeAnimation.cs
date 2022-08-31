using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeAnimation : MonoBehaviour
{
    public void ElementShakeAnimation()
    {
        print(this.GetType().FullName + " ElementShakeAnimation() ");

        //this.transform.
        //this.transform.DOShakePosition(2.0f, 0.5f, 5, 45, true, false).SetLoops(-1);
        this.transform.DOPunchScale(new Vector3(0.10f, 0.10f, 0f),1f,5,1);
        this.GetComponent<SpriteRenderer>().Fade(1);
    }
}
