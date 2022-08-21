using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public class ModuleCreator : EditorWindow
{
    enum EModuleType
    {
        Game,
        Unity
    }

    const string GAME_MODULES_PATH = "Assets/Scripts/GameModules";
    const string UNITY_MODULES_PATH = "Assets/Scripts/UnityModules";

    [MenuItem("Assets/Create Module")]
    static void Open()
    {
        ModuleCreator window = ScriptableObject.CreateInstance<ModuleCreator>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 400, 30);
        window.ShowPopup();
    }

    string _moduleName;
    EModuleType _type;
    private void OnGUI()
    {
        _moduleName = EditorGUILayout.TextField("Name", _moduleName);
        _type = (EModuleType)EditorGUILayout.EnumPopup("Type", _type);
        using (new GUILayout.HorizontalScope())
        {
            if (GUILayout.Button("Create"))
            {
                CreateModule();
                Close();
            }
            if (GUILayout.Button("Cancel"))
            {
                Close();
            }
        }
    }

    void CreateModule()
    {
        string path = string.Empty;
        switch (_type)
        {
            case EModuleType.Game:
                path = GAME_MODULES_PATH;
                break;
            case EModuleType.Unity:
                path = UNITY_MODULES_PATH;
                break;
        }

        var root = Path.Combine(path, _moduleName);
        Directory.CreateDirectory(root);

        StringBuilder assemblyBuilder = new();
        string CreateAssemblyFolder(string assemblyName, params string[] referenceGuids)
        {
            var assemblyPath = Path.Combine(root, assemblyName);
            Directory.CreateDirectory(assemblyPath);

            assemblyBuilder.Clear();
            assemblyBuilder.AppendLine("{");
            assemblyBuilder.AppendLine($"   \"name\": \"{_moduleName}.{assemblyName}\",");
            assemblyBuilder.AppendLine($"   \"rootNamespace\": \"{_moduleName}.{assemblyName}\",");
            if (referenceGuids.Length > 0)
            {
                assemblyBuilder.AppendLine($"   \"references\": [");
                for (int i = 0; i < referenceGuids.Length; i++)
                {
                    assemblyBuilder.AppendLine($"       \"GUID:{referenceGuids[i]}\"{(i < referenceGuids.Length - 1 ? "," : "")}");
                }
                assemblyBuilder.AppendLine($"   ],");
            }
            assemblyBuilder.AppendLine("    \"includePlatforms\": [],");
            assemblyBuilder.AppendLine("    \"excludePlatforms\": [],");
            assemblyBuilder.AppendLine("    \"allowUnsafeCode\": false,");
            assemblyBuilder.AppendLine("    \"overrideReferences\": false,");
            assemblyBuilder.AppendLine("    \"precompiledReferences\": [],");
            assemblyBuilder.AppendLine("    \"autoReferenced\": true,");
            assemblyBuilder.AppendLine("    \"defineConstraints\": [],");
            assemblyBuilder.AppendLine("    \"versionDefines\": [],");
            assemblyBuilder.AppendLine("    \"noEngineReferences\": false");
            assemblyBuilder.AppendLine("}");

            var asmpath = Path.Combine(assemblyPath, $"{_moduleName}.{assemblyName}.asmdef");
            File.AppendAllText(asmpath, assemblyBuilder.ToString());
            AssetDatabase.ImportAsset(asmpath);

            return AssetDatabase.AssetPathToGUID(asmpath);
        }

        var viewModel = CreateAssemblyFolder("ViewModel");
        var model = CreateAssemblyFolder("Model", viewModel);
        var data = CreateAssemblyFolder("Data", viewModel);
        var services = CreateAssemblyFolder("Services", data, model, viewModel);
        var commands = CreateAssemblyFolder("Commands", data, model, viewModel, services);
        var view = CreateAssemblyFolder("View", commands, viewModel);
        var test = CreateAssemblyFolder("Test", commands, view, viewModel);

        AssetDatabase.Refresh();
        var rootFolder = AssetDatabase.LoadAssetAtPath(root, typeof(Object));
        Debug.Log($"Created new module: {root}", rootFolder);
        EditorGUIUtility.PingObject(rootFolder);
        Selection.activeObject = rootFolder;
    }
}
