using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Linq;
using System.IO;

[CustomEditor(typeof(TileDataCollection))]
public class TileDataEditor : Editor
{
    const string LIST_ELEMENT_UXML_PATH = "Assets/Scripts/Game/Data/Tiles/Editor/TileDataListElement.uxml";
    const string MAIN_UXML_PATH = "Assets/Scripts/Game/Data/Tiles/Editor/TileDataEditor.uxml";
    const string TILEDATA_EDITOR_CONFIG_PATH = "Assets/Scripts/Game/Data/Tiles/Editor/TileDataEditorConfig.asset";

    TileDataEditorConfig _config;
    Dictionary<string, Button> _toolbarButtons = new Dictionary<string, Button>();
    ListView _list;

    public override VisualElement CreateInspectorGUI()
    {
        _config = AssetDatabase.LoadAssetAtPath<TileDataEditorConfig>(TILEDATA_EDITOR_CONFIG_PATH);
        _toolbarButtons.Clear();

        var tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(MAIN_UXML_PATH).Instantiate();
        SetToolBar(tree.Q("TypeTabs"));

        _list = tree.Q<ListView>("TileList");
        ConfigureList();

        SelectType(_toolbarButtons.First().Key);
        return tree;
    }

    void SetToolBar(VisualElement root)
    {
        root.Clear();
        foreach (var t in _config.TypeConfigs)
        {
            var button = new ToolbarButton();
            button.text = t.Name;
            button.clicked += () => SelectType(t.Name);
            root.Add(button);
            _toolbarButtons.Add(t.Name, button);
        }
    }

    void ConfigureList()
    {
        int ChangeSprite(int index, TileData data, Image image, Label spriteCount)
        {
            var n = data.Sprites.Length;
            index = (index + n) % n;
            image.sprite = data.Sprites[index];
            spriteCount.text = $"{index+1}/{n}";
            return index;
        }

        _list.bindItem = (element, index) =>
        {
            var data = (TileData)_list.itemsSource[index];
            var image = element.Q<Image>("Sprite");
            var spriteCount = element.Q<Label>("SpriteCount");
            var multipleSprites = data.Sprites.Length > 1; ;
            ChangeSprite(0, data, image, spriteCount);
            element.Q("SelectSpriteButtons").visible = multipleSprites;
            if (multipleSprites)
            {
                int selectedIndex = 0;
                var left = element.Q<Button>("SelectLeftSprite");
                left.clicked += () => selectedIndex = ChangeSprite(selectedIndex - 1, data, image, spriteCount);
                var right = element.Q<Button>("SelectRightSprite");
                right.clicked += () => selectedIndex = ChangeSprite(selectedIndex + 1, data, image, spriteCount);
            }

            var asset = element.Q<ObjectField>("TileDataAsset");
            asset.SetValueWithoutNotify(data);
        };

        var elementTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(LIST_ELEMENT_UXML_PATH);
        _list.makeItem = () =>
        {
            var element = elementTemplate.Instantiate();
            var asset = element.Q<ObjectField>("TileDataAsset");
            asset.objectType = typeof(TileData);
            return element;
        };
    }

    void SelectType(string type)
    {
        foreach (var b in _toolbarButtons)
        {
            b.Value.SetEnabled(b.Key != type);
        }

        ShowTypeData(type);
    }

    void ShowTypeData(string type)
    {
        var collection = target as TileDataCollection;
        var data = collection.GetTypeData(type);
        if (data == null)
        {
            data = CreateNewTypeData(type);
        }

        _list.itemsSource = data.Tiles;
        _list.Rebuild();
    }

    TileTypeData CreateNewTypeData(string name)
    {
        var rootPath = GetTargetPath();
        var typeDataPath = Path.Combine(rootPath, name);
        if (!AssetDatabase.IsValidFolder(typeDataPath))
        {
            AssetDatabase.CreateFolder(rootPath, name);
        }

        var typeData = ScriptableObject.CreateInstance<TileTypeData>();
        typeData.Type = name;
        typeData.MoveCost = 1;

        var typeDataAssetPath = Path.Combine(typeDataPath, name + ".asset");
        AssetDatabase.CreateAsset(typeData, typeDataAssetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        return typeData;
    }

    string GetTargetPath()
    {
        var assetPath = AssetDatabase.GetAssetPath(target); ;
        return Path.GetDirectoryName(assetPath);
    }
}
