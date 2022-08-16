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
    public static List<Vector3> pathArray = new List<Vector3>();


}
