using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NinjaAnimation : MonoBehaviour {
    public GameObject Player;
    private int HurtAnimationsCount = 0;
    SpriteRenderer my2dsprite;
    Animator anim;
	// Use this for initialization
	void Start () {
        my2dsprite = GetComponent<SpriteRenderer>();
        my2dsprite.gameObject.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        anim = GetComponent<Animator>();
    }
    IEnumerator MainMenuScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenuScene");

    }
    // Update is called once per frame
    void Update () {
        if (anim.GetBool("Hurt"))
            StartCoroutine(WaitForAnimation());
        if (HurtAnimationsCount == 3)
        {
            StartCoroutine(Die());
            StartCoroutine(MainMenuScene());
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("PlayerClose", true);
            if (Physics2D.Linecast(transform.position, transform.position + new Vector3(-2.2f, 0, 0), 1 << LayerMask.NameToLayer("Player")))
            {
                Player.GetComponent<Animator>().SetBool("Hurt", true);
                Player.GetComponent<Animator>().SetInteger("HurtAnimations", HurtAnimationsCount++);
                Debug.Log(HurtAnimationsCount.ToString());

            }
            StartCoroutine(Hit());


        }
        
    }
    IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("PlayerClose", false);


    }
    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("Hurt", false);
    }
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        Destroy(Player);
    }
}
