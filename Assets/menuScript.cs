using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{

    [SerializeField]
    AudioClip amogus;
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Amogus()
    {
        Camera.main.GetComponent<AudioSource>().clip = amogus;
        Camera.main.GetComponent<AudioSource>().Play();
    }
}
