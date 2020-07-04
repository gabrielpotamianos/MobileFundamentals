using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerFG : MonoBehaviour {

    public static AudioClip Collide, Drown, End, Background, MetalStick;
    public static AudioSource AudioSrc;
    // Use this for initialization
	void Start () {
        Collide = Resources.Load<AudioClip>("Collision");
        Drown = Resources.Load<AudioClip>("WaterCollision");
        End = Resources.Load<AudioClip>("EndPopping");
        MetalStick = Resources.Load<AudioClip>("MetalStick");
        Background = Resources.Load<AudioClip>("BackgroundSound");
        AudioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void PlaySound(string clip)
    {
        switch(clip){
            case "Collision":
                AudioSrc.PlayOneShot(Collide);
                break;
            case "Drown":
                AudioSrc.PlayOneShot(Drown);
                break;
            case "End":
                AudioSrc.PlayOneShot(End);
                break;
            case "MetalStick":
                AudioSrc.PlayOneShot(MetalStick);
                break;
            case "Background":
                AudioSrc.PlayOneShot(Background);
                break;



        }
    }
}
