using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Persist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // dont destroy me when loading a new scene
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.Z))
            SceneManager.LoadScene(1);
        if (Input.GetKeyDown(KeyCode.C))
            SceneManager.LoadScene(2);
        if (Input.GetKeyDown(KeyCode.V))
            SceneManager.LoadScene(3);
    }
}
