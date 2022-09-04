using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteScript : MonoBehaviour
{
    [SerializeField]
    GameEvent EventJarOutAnimation;
    

    public void LevelCompleted()
    {
        print(this.GetType().Name + " Level is now Completed");
        EventJarOutAnimation.Raise();        
        UIManager.Instance.EnableNextButton(true);
    }
}
