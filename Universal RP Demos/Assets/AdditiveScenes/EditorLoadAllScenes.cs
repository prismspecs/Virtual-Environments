using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]

public class EditorLoadAllScenes
{

    public static Scene[] ScenesToLoad;

    static EditorLoadAllScenes()
    {
        for(int i = 0; i < ScenesToLoad.Length; i++)
        {
            EditorSceneManager.LoadScene(ScenesToLoad[i].name, LoadSceneMode.Additive);
        }

        Debug.Log("Up and running");

    }
}