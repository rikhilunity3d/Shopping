using UnityEngine;
using DG.Tweening;

public class JarAnimation : MonoBehaviour
{
    [SerializeField]
    Vector3 InAnimationPos;

    [SerializeField]
    Vector3 OutAnimationPos;
    public GameEvent EventJarLidOutAnimation;
    private void Start()
    {
        GameEventHub.GOJarBack = this.gameObject;
    }

    public void JarInAnimation()
    {
        print(this.GetType().FullName + " Jar In Animation");
        //new Vector3(-7.80f, 3.90f, 0)
        this.transform.DOMove(InAnimationPos, 2f)
            .SetEase(Ease.OutQuad)
            .OnComplete(JarLidAnimation);
        //Vector3(-4.44999981,-0.660000026,0)
    }

    public void JarOutAnimation()
    {
        print(this.GetType().FullName + " Jar Out Animation");
        //new Vector3(-11.0f, -0.660000026f, 0), 2f)
        this.transform.DOMove(OutAnimationPos, 2f)
            .SetEase(Ease.OutQuad)
            .Complete();
    }
    public void JarLidAnimation()
    {
        print(this.GetType().FullName + " Jar Lid Animation Play");
        EventJarLidOutAnimation.Raise();
    }
}
