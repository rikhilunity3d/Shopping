using UnityEngine;
using UnityEditor;


public class WindowItemCreator : EditorWindow
{
    string enterName = "";
    int objectId = 1;
    Sprite displaySprite;
    GameObject objectToCreate;
    GameObject parentGameObject;

    [MenuItem("Tools/CreateBackground/CreateWindow/CreateWindowItem")]
    public static void ShowWindow()
    {
        GetWindow(typeof(WindowItemCreator));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spaw New Object", EditorStyles.boldLabel);

        displaySprite = EditorGUILayout.ObjectField("Sprite: ", displaySprite, typeof(Sprite),true) as Sprite;

        enterName = EditorGUILayout.TextField("Enter Name:", displaySprite?.name.ToString());

        parentGameObject = EditorGUILayout.ObjectField("Parent GO:",parentGameObject, typeof(GameObject),true) as GameObject;

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
            objectToCreate.AddComponent<ItemClickHandler>();
            objectToCreate.GetComponent<EventListener>().enabled = false;
            objectToCreate.GetComponent<SpriteRenderer>().sprite = displaySprite;
            objectToCreate.GetComponent<BoxCollider2D>().isTrigger = true;
            objectId++;
        }
    }
}
