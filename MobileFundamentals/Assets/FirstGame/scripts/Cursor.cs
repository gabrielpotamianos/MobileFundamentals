using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

    public GameObject Prefab;
    private GameObject cursor;
    // Use this for initialization
    void Start () {
      
        cursor = Instantiate(Prefab, new Vector2(0, 0), Quaternion.identity);
        cursor.GetComponent<BoxCollider2D>().isTrigger = true;
        cursor.GetComponent<Rigidbody2D>().freezeRotation = true;
    }
    // Update is called once per frame
    void Update () {
        cursor.GetComponent<BoxCollider2D>().isTrigger = true;
       
        Vector2 RayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        cursor.transform.position = RayPos;
        cursor.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
        
    }

}
