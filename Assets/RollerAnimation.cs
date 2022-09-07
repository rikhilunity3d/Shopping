using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerAnimation : MonoBehaviour
{
    List<GameObject> RollerChildGO = new List<GameObject>();
    private void Awake()
    {
        for(int i=0; i< transform.childCount;i++)
        {
            RollerChildGO.Add(transform.GetChild(i).gameObject);
        }
            
    }
    private void OnEnable()
    {
        GameEventHub.Print(GetType(), "In StartRollerAnimation condition loop ");
        StartRollerAnimation();
    }
    // Start is called before the first frame update
    async void StartRollerAnimation()
    { 
        for (int i = 0; i< RollerChildGO.Count; i++)
        {
            RollerChildGO[i].SetActive(!RollerChildGO[i].activeInHierarchy);



                await new WaitForSeconds(0.20f);
        }

        StartRollerAnimation();
    }

}
