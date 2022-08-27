using UnityEngine;
using UnityEditor;

public class DisplayItemParentCreator : EditorWindow
{

    string enterName = "";
    int objectId = 1;
    Sprite displaySprite;
    GameObject objectToCreate;
    SetCameraOrthographicSizeAccordingToBackground parentGameObject;

    [MenuItem("Tools/CreateDisplayParentItem")]
    public static void ShowWindow()
    {
        GetWindow(typeof(DisplayItemParentCreator));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spaw New Object", EditorStyles.boldLabel);

        displaySprite = EditorGUILayout.ObjectField("Sprite: ", displaySprite, typeof(Sprite),false) as Sprite;

        enterName = EditorGUILayout.TextField("Enter Name:", displaySprite?.name);

        parentGameObject = EditorGUILayout.ObjectField("Parent GO:", parentGameObject, typeof(SetCameraOrthographicSizeAccordingToBackground),true) as SetCameraOrthographicSizeAccordingToBackground;

        objectId = EditorGUILayout.IntField("Game Object ID", objectId);

        if (GUILayout.Button("Create Display Item"))
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
            objectToCreate.AddComponent<GetAllChildGameObjects>();
            objectToCreate.GetComponent<SpriteRenderer>().sprite = displaySprite;
            objectId++;
        }

    }
}
