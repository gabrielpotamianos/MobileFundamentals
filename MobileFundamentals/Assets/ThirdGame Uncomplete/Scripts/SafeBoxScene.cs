using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeBoxScene : MonoBehaviour {
    GameObject lookingAt;
    RaycastHit2D hit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        hit = Physics2D.Raycast(ray, Vector2.zero, 0f);
        if (hit)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                lookingAt = hit.transform.gameObject;

                //if (lookingAt.tag == "BackArrow")
                //    SceneManager.LoadScene("ThirdScene");
            
            }

    }

}
