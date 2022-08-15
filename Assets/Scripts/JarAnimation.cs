using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JarAnimation : MonoBehaviour
{
    public GameEvent EventJarLidOutAnimation;
    public void JarInAnimation()
    {
        print(this.GetType().FullName + " Jar In Animation");

        this.transform.DOMove(new Vector3(-4.44999981f, -0.660000026f, 0), 2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(JarLidAnimation);
        //Vector3(-4.44999981,-0.660000026,0)
    }

    public void JarOutAnimation()
    {
        print(this.GetType().FullName + " Jar Out Animation");
        this.transform.DOMove(new Vector3(-11.0f, -0.660000026f, 0), 2f)
            .SetEase(Ease.OutQuad)
            .Complete();
    }
    public void JarLidAnimation()
    {
        print(this.GetType().FullName + " Jar Lid Animation Play");
        EventJarLidOutAnimation.Raise();
    }
}
