using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerSG : MonoBehaviour
{

    public static AudioClip Collide, Land, OpenPortal,Portal,ClosePortal,Coin, Background,RemoveHingeJoint,star,HeavyImpact;
    public static AudioSource AudioSrc;
    // Use this for initialization
    void Start()
    {
        Collide = Resources.Load<AudioClip>("HitPlayer");
        Land = Resources.Load<AudioClip>("LandPlayer");
        OpenPortal = Resources.Load<AudioClip>("OpenPortal");
        Portal = Resources.Load<AudioClip>("PortalOpened");
        ClosePortal = Resources.Load<AudioClip>("ClosePortal");
        Coin = Resources.Load<AudioClip>("Coin");
        Background = Resources.Load<AudioClip>("Background");
        RemoveHingeJoint = Resources.Load<AudioClip>("RemoveHinge");
        star = Resources.Load<AudioClip>("Star");
        HeavyImpact = Resources.Load<AudioClip>("HeavyImpact");
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
            case "HitPlayer":
                AudioSrc.PlayOneShot(Collide);
                break;
            case "Land":
                AudioSrc.PlayOneShot(Land);
                break;
            case "OpenPortal":
                AudioSrc.PlayOneShot(OpenPortal);
                break;
            case "PortalOpened":
                AudioSrc.PlayOneShot(Portal);
                break;
            case "Background":
                AudioSrc.PlayOneShot(Background);
                break;
            case "ClosePortal":
                AudioSrc.PlayOneShot(ClosePortal);
                break;
            case "Coin":
                AudioSrc.PlayOneShot(Coin);
                break;
            case "RemoveHinge":
                AudioSrc.PlayOneShot(RemoveHingeJoint);
                break;
            case "Star":
                AudioSrc.PlayOneShot(star);
                break;
            case "HeavyImpact":
                AudioSrc.PlayOneShot(HeavyImpact);
                break;
        }
    }
}
