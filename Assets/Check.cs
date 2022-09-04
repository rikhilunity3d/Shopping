using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    [SerializeField]
    List<GameObject> list = new List<GameObject>();
    [SerializeField]
    CheckName checkName;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<list.Count;i++)
        {
            list[i].SetActive(list[i].name.Equals(CheckName.SonamPanel.ToString()));
        }
    }
}

public enum CheckName
{
    RikhilPanel,
    HoneyPanel,
    SonamPanel
}