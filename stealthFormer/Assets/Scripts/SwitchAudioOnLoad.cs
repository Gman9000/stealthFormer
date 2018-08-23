using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudioOnLoad : MonoBehaviour
{
    public AudioClip newTrack;

    private AudioManager theAM;

    // Use this for initialization
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();

        if (newTrack != null)
        {
            theAM.ChangeBGM(newTrack);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
