using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
using System;

namespace MeshGenerator.Editor
{
    [CustomEditor(typeof(MeshPreviewer))]
    public class MeshPreviewerEditor : UnityEditor.Editor
    {
        static Dictionary<Type, IMeshGeneratorEditor> _generatorToPreview;

        IMeshGeneratorEditor _currentEditor;
        IGeometryGenerator _currentGenerator;
        Transform _rootTransform;

        void GetPreviews()
        {
            _generatorToPreview = new();
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var attr = type.GetCustomAttribute<MeshGeneratorEditorAttribute>();
                if (attr != null)
                {
                    var previewer = (IMeshGeneratorEditor)Activator.CreateInstance(attr.EditorType);
                    _generatorToPreview.Add(attr.GeneratorType, previewer);
                }
            }
        }

        public static void RegisterPreviewer<TGenerator, TPreview>()
            where TGenerator : IGeometryGenerator
            where TPreview : IMeshGeneratorEditor, new()
        {
        }

        private void OnEnable()
        {
            GetPreviews();
            
            var transformProp = serializedObject.FindProperty("_generatorTransform");
            _rootTransform = (Transform)transformProp.objectReferenceValue;

            var typeProp = serializedObject.FindProperty("_meshType");
            UpdateEditor((EMeshType)typeProp.enumValueIndex);
        }

        public override void OnInspectorGUI()
        {
            if(_generatorToPreview==null)
            {
                GetPreviews();
            }

            var previewer = target as MeshPreviewer;

            var typeProp = serializedObject.FindProperty("_meshType");
            using (var changeCheck = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(typeProp);
                if (changeCheck.changed)
                {
                    UpdateEditor((EMeshType)typeProp.enumValueIndex);
                }
            }

            var transformProp = serializedObject.FindProperty("_generatorTransform");
            using (var changeCheck = new EditorGUI.ChangeCheckScope())
            {
                EditorGUILayout.PropertyField(transformProp);
                if (changeCheck.changed)
                {
                    _rootTransform = (Transform)transformProp.objectReferenceValue;
                }
            }

            if (_currentEditor != null)
            {
                using (var cc = new EditorGUI.ChangeCheckScope())
                {
                    _currentEditor.DrawInspectorGUI();

                    if (cc.changed)
                    {
                        SceneView.RepaintAll();
                    }
                }
            }

            if (GUILayout.Button("Generate Mesh"))
            {
                var mesh = Generate();
                previewer.SetMesh(mesh);
            }

            serializedObject.ApplyModifiedProperties();
        }

        void UpdateEditor(EMeshType type)
        {
            switch (type)
            {
                case EMeshType.Cube:
                    _currentGenerator = new CubeGenerator();
                    break;
                case EMeshType.House:
                    _currentGenerator = new HouseGenerator();
                    break;
                case EMeshType.Surface:
                    _currentGenerator = new SurfaceModelMeshGenerator(new());
                    break;
                default:
                    _currentGenerator = null;
                    break;
            }

            _generatorToPreview.TryGetValue(_currentGenerator.GetType(), out _currentEditor);
            if (_currentEditor != null)
            {
                _currentEditor.SetGenerator(_currentGenerator);
            }
        }

        public Mesh Generate()
        {
            var builder = new MeshBuilder();
            builder.PushMatrix(Matrix4x4.TRS(_rootTransform.localPosition, _rootTransform.localRotation, _rootTransform.localScale));
            builder.Generate(_currentGenerator);
            return builder.Build();
        }

        private void OnSceneGUI()
        {
            var previewer = target as MeshPreviewer;
            _currentEditor?.DrawSceneGUI(_rootTransform);
        }
    }
}
