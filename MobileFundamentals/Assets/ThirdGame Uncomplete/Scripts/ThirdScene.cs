using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThirdScene : MonoBehaviour {

    GameObject lookingAt;
    RaycastHit2D hit;
    public GameObject Key;
    public GameObject[] inventory = new GameObject[8];
    public List<Button> InventoryButton = new List<Button>(8);

    // Use this for initialization
    void Start()
    {
        InventoryButton.AddRange(GameObject.FindGameObjectWithTag("Inventory").GetComponentsInChildren<Button>());
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

                if (lookingAt.tag == "SafeBox")
                    SceneManager.LoadScene("SafeBoxSceneThirdGame");
            }
        if(ButtonHandler.foundKey)
        {
            addItem(Key, Key.tag);
            ButtonHandler.foundKey = false;
        }

    }
    private void addItem(GameObject Item, string tagGO)
    {
        bool full = true;
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = Item;
                inventory[i].tag = tagGO;
                InventoryButton[i].image.overrideSprite = Item.GetComponent<SpriteRenderer>().sprite;
                full = false;
                break;
            }
        }
        if (full)
            Debug.Log("Inventory Full!");
    }
}
