using UnityEditor;
using UnityEngine;


public class BackgroundCreator : EditorWindow
{
    string enterName = "";
    int objectId = 1;
    Sprite backgroundSprite;
    GameObject objectToCreate;

    [MenuItem("Tools/CreateBackground")]
    public static void ShowWindow()
    {
        GetWindow(typeof(BackgroundCreator));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spaw New Object", EditorStyles.boldLabel);

        backgroundSprite = EditorGUILayout.ObjectField("Sprite: ", backgroundSprite, typeof(Sprite),false) as Sprite;

        enterName = EditorGUILayout.TextField("Enter Name:", backgroundSprite?.name);

        objectId = EditorGUILayout.IntField("Game Object ID", objectId);

        if (GUILayout.Button("Create"))
        {
            CreateGameObject();
        }

        
    }
    private void CreateGameObject()
    {
        if(enterName == string.Empty)
        {
            EditorGUILayout.HelpBox("Error: Please enter an gameobject name to be created",MessageType.Error);
            return;
        }
        objectToCreate = new GameObject{name = enterName};
        objectToCreate.transform.position = new Vector3(0f, 0f, 0f);
        objectToCreate.AddComponent<SetCameraOrthographicSizeAccordingToBackground>();
        objectToCreate.GetComponent<SpriteRenderer>().sprite = backgroundSprite;
        objectId++;
    }
}
