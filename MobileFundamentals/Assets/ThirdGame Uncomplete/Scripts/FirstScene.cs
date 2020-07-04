using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class FirstScene : MonoBehaviour
{
    public Sprite Door;
    public GameObject lookingAt;
    private RaycastHit2D hit;
    private GameObject PaperOpen;
    bool DoorUnlocked = false;
    public List<GameObject> inventory = new List<GameObject>();
    public List<Button> InventoryButton = new List<Button>(8);

    public static int SceneNumber = 1;
    public static GameObject FirstCanvas;
    public static GameObject SecondCanvas;
    public static GameObject ThirdCanvas;
    public static GameObject InventoryCanvas;
    public static GameObject SafePin;

    private void addItem(GameObject Item, string tagGO)
    {
        bool full = true;
        if (inventory.Count < 8)
        {
            inventory.Add(Item);
            InventoryButton[inventory.Count - 1].image.overrideSprite = Item.GetComponent<SpriteRenderer>().sprite;
            full = false;
        }
        if (full)
            Debug.Log("Inventory Full!");
    }


    // Use this for initialization
    void Start()
    {
        InventoryButton.AddRange(GameObject.FindGameObjectWithTag("Inventory").GetComponentsInChildren<Button>());
        PaperOpen = GameObject.Find("PaperOpen").gameObject;
        PaperOpen.SetActive(false);
        FirstCanvas = GameObject.Find("Canvas 1").gameObject;
        SecondCanvas = GameObject.Find("Canvas 2").gameObject;
        ThirdCanvas = GameObject.Find("Canvas 3").gameObject;
        SafePin = GameObject.Find("Canvas 4").gameObject;
        InventoryCanvas = GameObject.Find("Inventory Canvas").gameObject;
        GameObject.FindGameObjectWithTag("Key").gameObject.SetActive(false);

        FirstCanvas.SetActive(false);
        SecondCanvas.SetActive(false);
        ThirdCanvas.SetActive(false);
        SafePin.SetActive(false);
        if (SceneNumber == 1)
            FirstCanvas.SetActive(true);
        else if (SceneNumber == 2)
            SecondCanvas.SetActive(true);
        else if (SceneNumber == 3)
            ThirdCanvas.SetActive(true);

    }
    private IEnumerator displayMessage()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("DoorLocked").GetComponent<Text>().enabled = false;
    }
    void Update()
    {
        Vector2 ray = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        hit = Physics2D.Raycast(ray, Vector2.zero, 0f);
        if (hit)
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                lookingAt = hit.transform.gameObject;

                if (lookingAt.tag == "Door")
                {
                    foreach (var i in inventory)
                        if (i.tag.Equals("Key"))
                        {
                            Destroy(i);
                            DoorUnlocked = true;
                            break;
                        }

                    if (DoorUnlocked)
                    {
                        Sprite currentSprite;
                        currentSprite = lookingAt.GetComponent<SpriteRenderer>().sprite;
                        lookingAt.GetComponent<SpriteRenderer>().sprite = Door;
                        Door = currentSprite;
                        StartCoroutine(NextLevel());
                    }
                    else
                    {
                        GameObject.Find("DoorLocked").GetComponent<Text>().enabled = true;
                        StartCoroutine(displayMessage());
                    }
                }

                if (lookingAt.tag == "TV")
                {
                    if (GameObject.Find("NoSignal1").GetComponent<SpriteRenderer>().enabled)
                    {
                        GameObject.Find("NoSignal1").GetComponent<SpriteRenderer>().enabled = false;
                        GameObject.Find("NoSignal1").GetComponent<Animator>().enabled = false;
                    }
                    else
                    {
                        GameObject.Find("NoSignal1").GetComponent<Animator>().enabled = true;
                        GameObject.Find("NoSignal1").GetComponent<SpriteRenderer>().enabled = true;
                    }
                }

                if (lookingAt.tag == "SafeBox")
                {
                    FirstCanvas.SetActive(false);
                    SecondCanvas.SetActive(false);
                    ThirdCanvas.SetActive(false);
                    InventoryCanvas.SetActive(false);
                    SafePin.SetActive(true);
                }

                if (lookingAt.tag == "Battery")
                {
                    addItem(lookingAt, "Battery");
                    lookingAt.SetActive(false);
                }
                if (lookingAt.tag == "Key")
                {
                    addItem(lookingAt, "Key");
                    lookingAt.SetActive(false);
                }

                if (lookingAt.tag == "Paper")
                    PaperOpen.SetActive(!PaperOpen.activeSelf);

                if (lookingAt.tag == "LeftArrow")
                {
                    if (SceneNumber < 3) SceneNumber++;
                    FirstCanvas.SetActive(false);
                    SecondCanvas.SetActive(false);
                    ThirdCanvas.SetActive(false);
                    if (SceneNumber == 1)
                        FirstCanvas.SetActive(true);
                    else if (SceneNumber == 2)
                        SecondCanvas.SetActive(true);
                    else if (SceneNumber == 3)
                        ThirdCanvas.SetActive(true);

                }
                if (lookingAt.tag == "RightArrow")
                {
                    if (SceneNumber > 1) SceneNumber--;

                    FirstCanvas.SetActive(false);
                    SecondCanvas.SetActive(false);
                    ThirdCanvas.SetActive(false);
                    if (SceneNumber == 1)
                        FirstCanvas.SetActive(true);
                    else if (SceneNumber == 2)
                        SecondCanvas.SetActive(true);
                    else if (SceneNumber == 3)
                        ThirdCanvas.SetActive(true);

                }

            }

    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenuScene");
    }

}
