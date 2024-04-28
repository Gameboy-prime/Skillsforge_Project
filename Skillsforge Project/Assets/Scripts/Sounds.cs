using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    AudioSource source;
    public AudioClip click;
    // Start is called before the first frame update
    private void Start()
    {
        source= GetComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        source.PlayOneShot(click);
    }
}
