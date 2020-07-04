using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    RaycastHit2D hit;
    Vector2 ray;
    GameObject lookingAt;
    public void AddItem(GameObject other)
    {
        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        hit = Physics2D.Raycast(ray, Vector2.zero, 0f);
        if (hit)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                lookingAt = hit.transform.gameObject;


            }
    }
}
