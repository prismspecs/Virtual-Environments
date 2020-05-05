using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IMPORTANT! Add scene manager
using UnityEngine.SceneManagement;

public class FadeIn : MonoBehaviour
{
    public AudioClip MyClip;
    public AudioSource MyAudioSource;

    public float FadeSpeed = .2f;

    public string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        MyAudioSource = GetComponent<AudioSource>();
        MyAudioSource.clip = MyClip;
        MyAudioSource.volume = 0f;
        MyAudioSource.Play();


    }

    // Update is called once per frame
    void Update()
    {
        MyAudioSource.volume += FadeSpeed * Time.deltaTime;

        if (MyAudioSource.volume > 1f)
            MyAudioSource.volume = 1f;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(NextScene);
    }
}
