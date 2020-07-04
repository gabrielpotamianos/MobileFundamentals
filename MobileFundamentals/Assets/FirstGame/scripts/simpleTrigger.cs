using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleTrigger : MonoBehaviour {

    public GameObject NewObject;
    Vector2 Raypos;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Raypos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cursor")
        {
            if (!gameObject.GetComponent<FixedJoint2D>())
                gameObject.AddComponent<FixedJoint2D>();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                gameObject.GetComponent<FixedJoint2D>().connectedBody = Instantiate(NewObject, Raypos, Quaternion.identity).GetComponent<Rigidbody2D>();
                SoundManagerFG.PlaySound("MetalStick");


            }

        }
    }
}
