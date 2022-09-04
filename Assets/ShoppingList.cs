using UnityEngine;

public class ShoppingList : MonoBehaviour
{
    public void EnableShoppingListPanel()
    {
        UIManager.Instance.EnablePanelWithName(PanelName.ShoppingListPanel);
    }
    public void DisableShoppingListPanel()
    {
        UIManager.Instance.DisablePanelWithName(PanelName.ShoppingListPanel);
    }
}
