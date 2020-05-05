using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEditor.SceneManagement;

public class LoadAllScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EditorSceneManager.LoadScene(4, LoadSceneMode.Additive);
        EditorSceneManager.LoadScene(5, LoadSceneMode.Additive);
        EditorSceneManager.LoadScene(6, LoadSceneMode.Additive);

        //SceneManager.LoadScene(4, LoadSceneMode.Additive);
        //SceneManager.LoadScene(5, LoadSceneMode.Additive);
        //SceneManager.LoadScene(6, LoadSceneMode.Additive);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
