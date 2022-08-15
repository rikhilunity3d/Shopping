using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarAnimation : MonoBehaviour
{
    
    public void JarInAnimation()
    {
        print(this.GetType().FullName + " JarInAnimation");
    }

    public void JarOutAnimation()
    {
        print(this.GetType().FullName + " JarOutAnimation");
    }
}
