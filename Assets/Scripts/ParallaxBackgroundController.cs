using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundController : MonoBehaviour
{
    Vector2 move;
    [SerializeField]
    private float speed;
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

        
        if (this.transform.position.x < -105)
        {

            return;
        }
        this.transform.position = new Vector2((this.transform.position.x +
                move.x * Speed * Time.deltaTime), this.transform.position.y);


    }
}




