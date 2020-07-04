using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    private RaycastHit2D hit;
    // Use this for initialization
    void Start()
    {
        SoundManagerSG.AudioSrc.volume = 0.8f;
        SoundManagerSG.PlaySound("Background");

    }

    // Update is called once per frame
    void Update()
    {
        SoundManagerSG.AudioSrc.volume = 0.8f;
        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        hit = Physics2D.Raycast(ray, Vector2.zero, 0f);
        if (hit)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                if (hit.transform.gameObject.tag == "HingeJoint")
                {
                    SoundManagerSG.AudioSrc.volume = 0.5f;
                    SoundManagerSG.PlaySound("RemoveHinge");
                    Destroy(hit.transform.gameObject);
                }
        }
    }
}
