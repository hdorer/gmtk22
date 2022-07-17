using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PitchRandomizer
{
    public static void PlaySoundPitchRandomized(AudioSource source, float minPitch, float maxPitch)
    {
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
    }
}
