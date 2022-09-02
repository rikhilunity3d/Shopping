using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundController : MonoBehaviour
{
    Vector2 move;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float leftXPos=-90;
    [SerializeField]
    private float rightXPos = 10;
    public float Speed { get => speed; set => speed = value; }

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            GameEventHub.Print(GetType(), "TouchPosition "+ touchPosition.ToString());
            if (touchPosition.x <0 )
            {
                move = Vector2.left;
                MoveBackground();
                GameEventHub.Print(GetType(), "In Left Touch");
            }
            else
            {
                move = Vector2.right;
                MoveBackground();

                GameEventHub.Print(GetType(), "In Right Touch");
            }
        }
        
    }

    public void MoveBackground()
    {
        if (transform.position.x < leftXPos && move == Vector2.left || transform.position.x > rightXPos && move == Vector2.right) 
        {
            return;
        }
        transform.position = new Vector2((this.transform.position.x +
                move.x * Speed * Time.deltaTime), this.transform.position.y);
    }
}




