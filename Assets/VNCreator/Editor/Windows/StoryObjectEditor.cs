﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using VNCreator.Editors;

namespace VNCreator
{
#if UNITY_EDITOR
    [CustomEditor(typeof(StoryObject))]
    public class StoryObjectEditor : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space(40);

            if (GUILayout.Button("Open", GUILayout.Height(40)))
            {
                StoryObjectEditorWindow.Open((StoryObject)target);
            }
        }
    }
#endif
}
