using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundController : MonoBehaviour
{
    Vector2 move = Vector2.left;
    [SerializeField]
    private float speed;
    public float Speed { get => speed; set => speed = value; }

    void Update()
    {
        MoveBackground();
    }

    public void MoveBackground()
    {
        this.transform.position = new Vector2((this.transform.position.x +
            move.x * Speed * Time.deltaTime), this.transform.position.y);
        if (this.transform.position.x < -105)
        {
            this.transform.position = new Vector2(0, 0);
        }
    }
}




