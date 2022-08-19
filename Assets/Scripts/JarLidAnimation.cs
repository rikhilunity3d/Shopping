using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JarLidAnimation : MonoBehaviour
{
    public GameEvent EventJarOutAnimation;
    public void JarLidOutAnimation()
    {
        this.transform.DOLocalMoveY(-10f, 2f).SetEase(Ease.OutQuad);
        print(this.GetType().FullName + " Play Jar Lid Out Animation");
    }

    public void JarLidInAnimation()
    {
        this.transform.DOLocalMoveY(0f, 2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(
            JarOutAnimation
            );
        print(this.GetType().FullName + " Play Jar Lid In Animation");
    }
    void JarOutAnimation()
    {
        EventJarOutAnimation.Raise();
    }
}
