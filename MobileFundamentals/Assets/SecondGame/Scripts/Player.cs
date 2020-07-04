using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject player;
	// Use this for initialization
	void Start () {
        player.GetComponent<Animator>().enabled = true;
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bar")
        {
            SoundManagerSG.PlaySound("HitPlayer");
            player.GetComponent<Animator>().enabled = false;

        }
        if (other.gameObject.tag == "Land")
            SoundManagerSG.PlaySound("LandPlayer");
     
    }
    private IEnumerator GetTheStar(Collider2D other)
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(other.gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            SoundManagerSG.PlaySound("Coin");
            StartCoroutine(GetTheStar(collision));
        }
    }


}
