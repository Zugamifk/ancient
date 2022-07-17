using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class MapEditorWindow : EditorWindow
{
    [MenuItem("Window/UI Toolkit/MapEditorWindow")]
    public static void ShowExample()
    {
        MapEditorWindow wnd = GetWindow<MapEditorWindow>();
        wnd.titleContent = new GUIContent("MapEditorWindow");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Scripts/UnityModules/MapEditor/MapEditorWindow.uxml");
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Scripts/UnityModules/MapEditor/MapEditorWindow.uss");

        VisualElement instance = visualTree.Instantiate();
        instance.styleSheets.Add(styleSheet);

        var terrain = instance.Q<ObjectField>("Terrain");
        terrain.objectType = typeof(Terrain);

        root.Add(instance);
    }
}