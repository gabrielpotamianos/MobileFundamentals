using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Run, Blade, HitHuman,ZombieKnife,ZombieHit,Land, Background;
    public static AudioSource AudioSrc;
    // Use this for initialization
    void Start()
    {
        Run = Resources.Load<AudioClip>("Running");
        Blade = Resources.Load<AudioClip>("HumanBlade");
        HitHuman = Resources.Load<AudioClip>("HumanHit");
        ZombieKnife = Resources.Load<AudioClip>("ZombieKnife");
        ZombieHit = Resources.Load<AudioClip>("ZombieHit");
        Land = Resources.Load<AudioClip>("LandPlayer");
        Background = Resources.Load<AudioClip>("Background");
        AudioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Run":
                AudioSrc.PlayOneShot(Run);
                break;
            case "Blade":
                AudioSrc.PlayOneShot(Blade);
                break;
            case "HitHuman":
                AudioSrc.PlayOneShot(HitHuman);
                break;
            case "ZombieKnife":
                AudioSrc.PlayOneShot(ZombieKnife);
                break;
            case "Background":
                AudioSrc.PlayOneShot(Background);
                break;
            case "ZombieHit":
                AudioSrc.PlayOneShot(ZombieHit);
                break;
            case "Land":
                AudioSrc.PlayOneShot(Land);
                break;
        }
    }
}
