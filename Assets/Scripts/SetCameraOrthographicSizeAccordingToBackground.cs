using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(EventListener))]
public class SetCameraOrthographicSizeAccordingToBackground : MonoBehaviour
{
    Sprite Background;
    [SerializeField]
    GameEvent EventSetCameraOrthographicSize;
    private void Awake()
    {
        Background = GetComponent<SpriteRenderer>().sprite;
    }
    private void OnEnable()
    {
        EventSetCameraOrthographicSize?.Raise();
    }
    // This function SetCameraOrthographicSize() will make sure our background
    // image width completely cover in camera. Height will be compromise
    // according to device. This function is also a listener and will respond to
    // an event.
    public void SetCameraOrthographicSize()
    {
        Camera.main.orthographicSize = Background.bounds.size.y / 2 * (GetTargetRatio() / GetScreenRatio());
        GameEventHub.Print(this.GetType(), "Set Camera Orthographic Size Function Call");
    }
    float GetScreenRatio()
    {
        return (float)Screen.width / (float)Screen.height; ;
    }
    float GetTargetRatio()
    {
        return Background.bounds.size.x / Background.bounds.size.y;
    }
}
