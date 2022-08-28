using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EventListener))]
public class SetCameraOrthographicSizeAccordingToBackground : MonoBehaviour
{
    Sprite Background;
    [SerializeField]
    GameEvent EventSetCameraOrthographicSize;
    [SerializeField]
    Orientation orientation;
    private void Awake()
    {
        Background = GetComponent<SpriteRenderer>().sprite;
        GameEventHub.Print(this.GetType(), " Awake "+Background.name);
    }
    private void Start()
    {
        GameEventHub.Print(this.GetType(), "OnStart");
        EventSetCameraOrthographicSize.Raise();
        GameEventHub.Print(this.GetType(), "EventSetCameraOrthographicSize Event Raised");
    }
    // This function SetCameraOrthographicSize() will make sure our background
    // image width completely cover in camera. Height will be compromise
    // according to device. This function is also a listener and will respond to
    // an event.
    public void SetCameraOrthographicSize()
    {
        GameEventHub.Print(this.GetType(), Background.name);
        switch (orientation)
        {
            case Orientation.height:
                Camera.main.orthographicSize = Background.bounds.size.y / 2;
                GameEventHub.Print(this.GetType(), (Background.bounds.size.x / 2 * (GetTargetRatio() / GetScreenRatio())).ToString());
                break;
            case Orientation.width:
                Camera.main.orthographicSize = Background.bounds.size.y / 2 * (GetTargetRatio() / GetScreenRatio());
                GameEventHub.Print(this.GetType(), "Set Camera Orthographic Size Function Call");
                break;
        }
    }

    float GetScreenRatio()
    {
        GameEventHub.Print(this.GetType(), " GetScreenRatio " + ((float)Screen.width / (float)Screen.height).ToString());
        return (float)Screen.width / (float)Screen.height;
    }

    float GetTargetRatio()
    {
        GameEventHub.Print(this.GetType(), " GetTargetRatio " + ((float)Background.bounds.size.x / (float)Background.bounds.size.y).ToString());
        return (float)Background.bounds.size.x / (float)Background.bounds.size.y;
    }
}

public enum Orientation{
    width,
    height
}