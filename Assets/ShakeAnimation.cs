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
        this.transform.DOShakePosition(2.0f, 0.5f, 5, 45, true, false).SetLoops(-1);

        //this.transform.DOScaleY(0.10f, 1.5f).SetEase(Ease.OutQuad).SetLoops(-1);
    }
}
