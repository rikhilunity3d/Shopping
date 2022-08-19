using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameEventHub class is only Data Container
public static class GameEventHub
{
    //  update each player score individually
    //  Handle different points per block
    //  Remove the need to hard reference the players
    //  Play particle effect of the player who collides only
    public static int itemCount;
    public static int indexForItem = 0;
    public static GameObject go;

    public static GameObject GOJarBack;
    public static List<GameObject> animationPathPoints = new List<GameObject>();

    static int printId=0;

    public static Vector3[] GetAnimationPathPoints()
    {
        List<Vector3> animationPathPointsArray = new List<Vector3>();
        for(int i=0;i< animationPathPoints.Count;i++)
        {
            animationPathPointsArray.Add(animationPathPoints[i].transform.position);
        }
        return animationPathPointsArray.ToArray();
    }

    public static void Print(System.Type type, string str)
    {
        printId++;
        Debug.Log(printId.ToString() + ":" + " Script Name: " + type.Name + " -> " + str);
    }
}
