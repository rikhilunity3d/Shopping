using UnityEngine;
using DG.Tweening;

public class CartClickHandler : MonoBehaviour
{
    GameObject ShopRef;
    CharacterController character;
    private void OnMouseDown()
    {
        GameEventHub.Print(GetType(), " OnMouseDown()");

        if (!transform.parent.GetComponent<CharacterController>())
        {
            ShopRef = this.transform.parent.gameObject;
            
            if (ShopRef != null)
            {
                // animate the cart towards character and after animation add cart as
                // a child of character. initially cart is a child of Shop GameObject
                // in hierarcy

                

                for (int i = 0; i < ShopRef.transform.childCount; i++)
                {
                    if (ShopRef.transform.GetChild(i).GetComponent<CharacterController>())
                    {
                        character = ShopRef.transform.GetChild(i).GetComponent<CharacterController>();
                        //transform.parent = ShopRef.transform.GetChild(i).GetComponent<CharacterController>().gameObject.transform;

                        transform.DOLocalMove(character.transform.position,2f)
                        .SetEase(Ease.OutQuad)
                        .SetSpeedBased(true)
                        .OnComplete(OnCompleteAnimation);

                        break;
                    }
                }
            }
        }
        

    }

    void OnCompleteAnimation()
    {
        GameEventHub.Print(GetType(), " OnCompleteAnimation()");
        transform.parent = character != null ? character.transform : null;
    }
}
