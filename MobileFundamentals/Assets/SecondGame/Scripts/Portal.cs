using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    public GameObject hamster;
    public Animator portal;
    public GameObject Star;
    // Use this for initialization
    void Start () {
        SoundManagerSG.AudioSrc.volume = 0.5f;
        SoundManagerSG.PlaySound("OpenPortal");
        portal.GetComponent<Animator>().SetBool("GameStart", true);
        Star.SetActive(false);
    }
    private IEnumerator DestroyPlayer()
    {
       
        yield return new WaitForSeconds(0.2f);
        SoundManagerSG.AudioSrc.volume = 0.5f;
        SoundManagerSG.PlaySound("ClosePortal");
        portal.GetComponent<Animator>().SetBool("PlayerEnter", true);
        Destroy(hamster);
    }
    private IEnumerator DestroyPortal()
    {
        yield return new WaitForSeconds(3);
        Star.SetActive(true);
        SoundManagerSG.AudioSrc.volume = 0.5f;
        SoundManagerSG.PlaySound("Star");
        portal.gameObject.SetActive(false);
        SceneManager.LoadScene("EndSecondGame", LoadSceneMode.Additive);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyPlayer());
            StartCoroutine(DestroyPortal());
        }
    }
}
