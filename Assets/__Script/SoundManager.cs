using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    static public SoundManager S = null;

    private void Awake()
    {
        if (S == null)
        {
            S = this;
        }
    }

    public List<AudioClip> audioClips;

    public void PlayEffectSound(int i)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClips[i]);
    }
}
