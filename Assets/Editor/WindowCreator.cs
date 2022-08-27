using UnityEngine;
using UnityEditor;

public class WindowCreator : EditorWindow
{
    string enterName = "";
    int objectId = 1;
    Sprite displaySprite;
    GameObject objectToCreate;
    SetCameraOrthographicSizeAccordingToBackground parentGameObject;

    [MenuItem("Tools/CreateBackground/CreateWindow")]
    public static void ShowWindow()
    {
        GetWindow(typeof(WindowCreator));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spaw New Object", EditorStyles.boldLabel);

        enterName = EditorGUILayout.TextField("Enter Name:", enterName);

        displaySprite = EditorGUILayout.ObjectField("Sprite: ", displaySprite, typeof(Sprite)) as Sprite;

        parentGameObject = EditorGUILayout.ObjectField("Parent GO:", parentGameObject, typeof(SetCameraOrthographicSizeAccordingToBackground)) as SetCameraOrthographicSizeAccordingToBackground;

        objectId = EditorGUILayout.IntField("Game Object ID", objectId);

        if (GUILayout.Button("Create Window"))
        {
            CreateGameObject();
        }
    }
    private void CreateGameObject()
    {
        if (enterName == string.Empty)
        {
            EditorGUILayout.HelpBox("Error: Please enter a gameobject name to be created", MessageType.Error);

        }
        if (parentGameObject == null)
        {
            EditorGUILayout.HelpBox("Error: Please enter a parent gameobject", MessageType.Error);

        }
        else
        {
            objectToCreate = new GameObject { name = enterName };
            objectToCreate.transform.parent = parentGameObject.transform;
            objectToCreate.transform.position = new Vector3(0f, 0f, 0f);
            objectToCreate.AddComponent<WindowOpenClose>();
            objectToCreate.AddComponent<EventListener>();
            objectToCreate.GetComponent<SpriteRenderer>().sprite = displaySprite;
            objectId++;
        }
    }
}
