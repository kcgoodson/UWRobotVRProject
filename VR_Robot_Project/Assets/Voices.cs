using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voices : MonoBehaviour
{
    public void test()
    {
        Debug.Log("Clicked");
    }

    public AudioClip MusicClip;

    public AudioSource MusicSource;

    void Start()
    {
        MusicSource.clip = MusicClip;
    }

    public void Play()
    {
        MusicSource.Play();
    }
}
