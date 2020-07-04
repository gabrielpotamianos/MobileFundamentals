using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{

    static GameObject FadeInGO;
    static GameObject FadeOutGO;

    void Start()
    {
        FadeInGO = GameObject.Find("FadeIn").gameObject;

        FadeOutGO = GameObject.Find("FadeOut").gameObject;
        FadeOutGO.SetActive(false);


        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(1);
        FadeInGO.SetActive(false);


    }
    IEnumerator FadeOut(string nameScene)
    {
        FadeOutGO.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nameScene);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SetScene(string nameScene)
    {
        StartCoroutine(FadeOut(nameScene));
    }
}
