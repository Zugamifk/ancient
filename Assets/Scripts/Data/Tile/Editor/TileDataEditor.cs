using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Linq;
using System.IO;
using System;

[CustomEditor(typeof(TileDataCollection))]
public class TileDataEditor : Editor
{
    class ListElementCallbacks
    {
        public EventCallback<ChangeEvent<UnityEngine.Object>> addSprite;
        public EventCallback<ChangeEvent<string>> onSelectNorthEdge;
        public EventCallback<ChangeEvent<string>> onSelectEastEdge;
        public EventCallback<ChangeEvent<string>> onSelectSouthEdge;
        public EventCallback<ChangeEvent<string>> onSelectWestEdge;
    }
    const string EDGE_WILDCARD = "*";
    const string LIST_ELEMENT_UXML_PATH = "Assets/Scripts/Data/Tile/Editor/TileDataListElement.uxml";
    const string MAIN_UXML_PATH = "Assets/Scripts/Data/Tile/Editor/TileDataEditor.uxml";
    const string TILEDATA_EDITOR_CONFIG_PATH = "Assets/Data/Tiles/TileDataEditorConfig.asset";

    TileDataEditorConfig _config;
    Dictionary<string, Button> _toolbarButtons = new Dictionary<string, Button>();
    ListView _list;
    List<string> _tileEdgeTypeOptions = new List<string>();
    TileTypeData _currentType;

    public override VisualElement CreateInspectorGUI()
    {
        _config = AssetDatabase.LoadAssetAtPath<TileDataEditorConfig>(TILEDATA_EDITOR_CONFIG_PATH);
        _tileEdgeTypeOptions.Clear();
        _tileEdgeTypeOptions.Add(EDGE_WILDCARD);
        _tileEdgeTypeOptions.AddRange(_config.TypeConfigs.Select(t => t.Name));
        _toolbarButtons.Clear();

        var tree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(MAIN_UXML_PATH).Instantiate();
        SetToolBar(tree.Q("TypeTabs"));

        _list = tree.Q<ListView>("TileList");
        ConfigureList();

        var newTilebutton = tree.Q<Button>("AddTile");
        newTilebutton.clicked += CreateNewTileData;

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
            var n = data.Sprites.Count;
            index = (index + n) % n;
            image.sprite = data.Sprites[index];
            spriteCount.text = $"{index + 1}/{n}";
            return index;
        }

        void SetUpdateCallback(ref EventCallback<ChangeEvent<string>> changeEvent, Action<string> setValue, DropdownField field)
        {
            field.UnregisterValueChangedCallback(changeEvent);
            changeEvent = ce => setValue(ce.newValue);
            field.RegisterValueChangedCallback(changeEvent);
        }

        _list.bindItem = (element, index) =>
        {
            var data = (TileData)_list.itemsSource[index];
            var image = element.Q<Image>("Sprite");
            var spriteCount = element.Q<Label>("SpriteCount");
            var multipleSprites = data.Sprites != null && data.Sprites.Count > 1; ;
            var callbacks = (ListElementCallbacks)element.userData;
            if (data.Sprites == null || data.Sprites.Count == 0)
            {
                image.image = EditorGUIUtility.IconContent("CrossIcon").image;
            } else
            {
                ChangeSprite(0, data, image, spriteCount);
            }
            element.Q("SelectSpriteButtons").visible = multipleSprites;
            if (multipleSprites)
            {
                int selectedIndex = 0;
                var left = element.Q<Button>("SelectLeftSprite");
                left.clicked += () => selectedIndex = ChangeSprite(selectedIndex - 1, data, image, spriteCount);
                var right = element.Q<Button>("SelectRightSprite");
                right.clicked += () => selectedIndex = ChangeSprite(selectedIndex + 1, data, image, spriteCount);
            }
            var newSpriteField = element.Q<ObjectField>("NewSpriteField");
            newSpriteField.UnregisterValueChangedCallback(callbacks.addSprite);
            callbacks.addSprite = ce =>
            {
                if (ce.newValue != null)
                {
                    Sprite sprite = (Sprite)ce.newValue;
                    data.Sprites.Add(sprite);
                    EditorUtility.SetDirty(data);
                    newSpriteField.SetValueWithoutNotify(null);
                    BuildTypePanel();
                }
            };
            newSpriteField.RegisterValueChangedCallback(callbacks.addSprite);

            Action<string> SetEdgeValue(Action<string> setter)
            {
                return value =>
                {
                    setter(value);
                    EditorUtility.SetDirty(data);
                };
            }
            var north = element.Q<DropdownField>("NorthEdge");
            north.value = string.IsNullOrEmpty(data.North) ? EDGE_WILDCARD : data.North;
            SetUpdateCallback(ref callbacks.onSelectNorthEdge, SetEdgeValue(v => data.North = v), north);
            var east = element.Q<DropdownField>("EastEdge");
            east.value = string.IsNullOrEmpty(data.East) ? EDGE_WILDCARD : data.East;
            SetUpdateCallback(ref callbacks.onSelectEastEdge, SetEdgeValue(v => data.East = v), east);
            var south = element.Q<DropdownField>("SouthEdge");
            south.value = string.IsNullOrEmpty(data.South) ? EDGE_WILDCARD : data.South;
            SetUpdateCallback(ref callbacks.onSelectSouthEdge, SetEdgeValue(v => data.South = v), south);
            var west = element.Q<DropdownField>("WestEdge");
            west.value = string.IsNullOrEmpty(data.West) ? EDGE_WILDCARD : data.West;
            SetUpdateCallback(ref callbacks.onSelectWestEdge, SetEdgeValue(v => data.West = v), west);

            var asset = element.Q<ObjectField>("TileDataAsset");
            asset.SetValueWithoutNotify(data);
        };

        var elementTemplate = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(LIST_ELEMENT_UXML_PATH);
        _list.makeItem = () =>
        {
            var element = elementTemplate.Instantiate();
            var asset = element.Q<ObjectField>("TileDataAsset");
            asset.objectType = typeof(TileData);
            asset.RegisterValueChangedCallback(ce =>
            {
                UpdateAssets();
            });
            var north = element.Q<DropdownField>("NorthEdge");
            north.choices = _tileEdgeTypeOptions;
            var east = element.Q<DropdownField>("EastEdge");
            east.choices = _tileEdgeTypeOptions;
            var south = element.Q<DropdownField>("SouthEdge");
            south.choices = _tileEdgeTypeOptions;
            var west = element.Q<DropdownField>("WestEdge");
            west.choices = _tileEdgeTypeOptions;
            var newSpriteField = element.Q<ObjectField>("NewSpriteField");
            newSpriteField.objectType = typeof(Sprite);
            element.userData = new ListElementCallbacks();
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
        var data = collection.GetTypeDataEditor(type);
        if (data == null)
        {
            data = CreateNewTypeData(type);
        }
        _currentType = data;
        BuildTypePanel();
    }

    void BuildTypePanel()
    {
        _list.itemsSource = _currentType.Tiles;
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

        var asset = AssetDatabase.LoadAssetAtPath<TileTypeData>(typeDataAssetPath);
        var collection = target as TileDataCollection;
        collection.Tiles.Add(asset);
        EditorUtility.SetDirty(collection);

        return typeData;
    }

    void CreateNewTileData()
    {
        var rootPath = GetTargetPath();
        var typeDataPath = Path.Combine(rootPath, _currentType.Type);
        var tileData = ScriptableObject.CreateInstance<TileData>();
        tileData.North = EDGE_WILDCARD;
        tileData.East = EDGE_WILDCARD;
        tileData.South = EDGE_WILDCARD;
        tileData.West = EDGE_WILDCARD;

        var tileDataAssetPath = Path.Combine(typeDataPath, _currentType.Type + $"Data{_currentType.Tiles.Count}.asset");
        AssetDatabase.CreateAsset(tileData, tileDataAssetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        var asset = AssetDatabase.LoadAssetAtPath<TileData>(tileDataAssetPath);
        _currentType.Tiles.Add(asset);
        EditorUtility.SetDirty(_currentType);
       
        BuildTypePanel();
    }

    string GetTargetPath()
    {
        var assetPath = AssetDatabase.GetAssetPath(target); ;
        return Path.GetDirectoryName(assetPath);
    }

    void UpdateAssets()
    {
        var collection = target as TileDataCollection;
        foreach (var typeConfig in _config.TypeConfigs)
        {
            var rootPath = GetTargetPath();
            var data = collection.GetTypeDataEditor(typeConfig.Name);
            if(data == null)
            {
                data = CreateNewTypeData(typeConfig.Name);
            }

            UpdateTypeData(data);
        }
        EditorUtility.SetDirty(this);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void UpdateTypeData(TileTypeData data)
    {
        data.Tiles.RemoveAll(t => t == null);
        int i = 0;
        foreach(var tile in data.Tiles)
        {
            var path = AssetDatabase.GetAssetPath(tile);
            AssetDatabase.RenameAsset(path, $"{data.Type}Data{i++}.asset");
            UpdateTileData(tile);
        }
        var assets = AssetDatabase.LoadAllAssetsAtPath(Path.GetDirectoryName(AssetDatabase.GetAssetPath(data)));
        foreach(var a in assets)
        {
            if (a is TileData && !data.Tiles.Contains(a))
            {
                AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(a));
            }
        }
        EditorUtility.SetDirty(data);
    }

    void UpdateTileData(TileData data)
    {
        EditorUtility.SetDirty(data);
    }
}
