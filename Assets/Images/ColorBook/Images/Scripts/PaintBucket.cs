using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBucket : MonoBehaviour
{
    public Color[] colorList;
    public Color currentColor;
    public int colorCount;

    private void Start()
    {

    }

    private void Update()
    {
        currentColor = colorList[colorCount];
        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(ray, -Vector2.up);
        if(Input.GetButton("Fire1"))
        {
            if(hit.collider!= null)
            {
                SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                GameEventHub.Print(GetType(),sp.name);
                
                currentColor.a = 1.0f;
                sp.color = currentColor;
            }
            if (hit.collider == null)
            {
                //Camera.main.backgroundColor = currentColor;
            }
        }
    }

    public void Paint(int colorCode)
    {
        colorCount = colorCode;
    }
}
