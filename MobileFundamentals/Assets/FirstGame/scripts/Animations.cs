using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Animations : MonoBehaviour {

    public Animator Time;
    public Animator FadeEffect;
    private Animator playerAnim;
    private bool GameOver = true;
    public bool willPlay = true;

    Vector3 Pos;
    // Use this for initialization
    void Start() {
        SoundManagerFG.PlaySound("Background");
        playerAnim = GetComponent<Animator>();
        Time.enabled = false;
    }

    // Update is called once per frame
    void Update() { }
    private IEnumerator wait2sec()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("FirstGameGameOver", LoadSceneMode.Additive);
        SoundManagerFG.PlaySound("End");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attachable")
        {
            playerAnim.SetBool("IsFalling?", true);
            Time.gameObject.SetActive(true);
            Time.enabled = true;
            if (GameOver)
            {
                GameOver = false;
                StartCoroutine(wait2sec());

            }


        }

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (willPlay == true)
        {
            if (collision.gameObject.tag == "acid")
        {
            SoundManagerFG.PlaySound("Drown");
            playerAnim.gameObject.transform.Rotate(Vector3.zero);
            playerAnim.SetBool("dead", true);
            playerAnim.SetBool("IsFalling?", false);
                willPlay = false;
        }
    }
}

}
