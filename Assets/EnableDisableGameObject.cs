using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableGameObject : MonoBehaviour
{
    public void EnableDisableGO()
    {
        GameEventHub.Print(GetType()," "+ !gameObject.activeSelf);
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
