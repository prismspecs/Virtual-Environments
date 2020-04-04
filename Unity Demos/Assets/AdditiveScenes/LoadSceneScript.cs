using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
            SceneManager.LoadScene("Additive-SoundObjects", LoadSceneMode.Additive);
        }
    }
}
