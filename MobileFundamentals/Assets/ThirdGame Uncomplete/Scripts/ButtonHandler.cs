using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    const string SecreteText = "9374";
    public static bool foundKey = false;
    GameObject key;
    GameObject Canvas1;
    GameObject Canvas2;
    GameObject Canvas3;
    GameObject Canvas4;
    GameObject CanvasInventory;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        key = GameObject.FindGameObjectWithTag("Key").gameObject;
        Canvas1 = GameObject.Find("Canvas 1").gameObject;
        Canvas2 = GameObject.Find("Canvas 2").gameObject;
        Canvas3 = GameObject.Find("Canvas 3").gameObject;
        Canvas4 = GameObject.Find("Canvas 4").gameObject;
        CanvasInventory = GameObject.Find("Inventory Canvas").gameObject;

    }

    public void SetText(string text)
    {
        GameObject.Find("Text").GetComponent<Text>().text += text;

    }
    public void deteleLastChar()
    {
        GameObject.Find("Text").GetComponent<Text>().text =
            GameObject.Find("Text").GetComponent<Text>().text.Substring(0, GameObject.Find("Text").GetComponent<Text>().text.Length - 1);
    }
    public void CheckText()
    {
        if (GameObject.Find("Text").GetComponent<Text>().text == SecreteText)
        {
            foundKey = true;


            Canvas1.SetActive(false);
            Canvas2.SetActive(false);
            Canvas3.SetActive(true);
            Canvas4.SetActive(false);
            CanvasInventory.SetActive(true);


            key.SetActive(true);
        }
    }

}
