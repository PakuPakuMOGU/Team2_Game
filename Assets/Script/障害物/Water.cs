using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public AudioSource startsound;
    public AudioSource finishsound;

    void OnTriggerEnter(Collider collider)
    {
        startsound.Play();
    }

    void OnTriggerExit(Collider collider)
    {
        finishsound.Play();
    }
}
