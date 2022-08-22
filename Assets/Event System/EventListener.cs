using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    // GameEvent variable to know which Event this listner should response to.
    public GameEvent Event;
    //  This UnityEvent Variable will allow us to drag and drop methods in the inspector
    public UnityEvent Response;
    
    private void OnEnable()
    {
        Event.Register(this);
    }
    public void OnEventRaise()
    {
        Response.Invoke();
    }
    private void OnDisable()
    {
        Event.DeRegister(this);
    }
}
