using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    private ParticleSystem PlayerParticle;
    public GameObject Enemy;
    public int HurtAnimationCount = 0;
    public float myJumpStrength;
    public float MoveSpeed;
    bool FacingRight = true;
    bool isParticlePlaying = false;
    bool onGround = true;
    Rigidbody2D Myrigid;
    SpriteRenderer my2dRenderer;
    Animator playerAnim;
    // Use this for initialization
    void Start()
    {
        Myrigid = gameObject.GetComponent<Rigidbody2D>();
        my2dRenderer = GetComponent<SpriteRenderer>();
        playerAnim = gameObject.GetComponent<Animator>();
        PlayerParticle = GetComponent<ParticleSystem>();

    }

    IEnumerator HurtAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("Hurt", false);
    }
    IEnumerator MainMenuScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenuScene");

    }

    // Update is called once per frame
    void Update()
    {

        if (HurtAnimationCount == 3)
        {
            StartCoroutine(KillEnemy());
            StartCoroutine(MainMenuScene());
        }
        //Check if Hurt
        if (playerAnim.GetBool("Hurt"))
            StartCoroutine(HurtAnimation());

        //RUNNING
        if (Input.GetAxis("Horizontal") < 0)

        {
            if (!isParticlePlaying && onGround)
            {
                PlayerParticle.Play();
                isParticlePlaying = !isParticlePlaying;
            }
            if (FacingRight)
            {
                my2dRenderer.gameObject.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                FacingRight = !FacingRight;

            }
            playerAnim.SetBool("startRunning", true);
            playerAnim.SetBool("run", true);
            Myrigid.velocity = new Vector2((Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime), Myrigid.velocity.y);

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (!isParticlePlaying && onGround)
            {
                PlayerParticle.Play();
                isParticlePlaying = !isParticlePlaying;
            }
            if (!FacingRight)
            {
                my2dRenderer.gameObject.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                FacingRight = !FacingRight;
            }
            playerAnim.SetBool("startRunning", true);
            playerAnim.SetBool("run", true);
            Myrigid.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime, Myrigid.velocity.y);


        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (isParticlePlaying)
            {
                PlayerParticle.Stop();
                isParticlePlaying = !isParticlePlaying;
            }
            playerAnim.SetBool("startRunning", false);
            playerAnim.SetBool("run", false);
        }
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -1.85f, 0), Color.blue);


        //JUMPING
        if (Input.GetAxis("Vertical") > 0)
            if (Physics2D.Linecast(transform.position, transform.position + new Vector3(0, -1.85f, 0), 1 << LayerMask.NameToLayer("Land")))
            {
                onGround = false;
                playerAnim.SetBool("inAir", true);
                StartCoroutine(WaitToJump());

            }
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, -3.5f, 0), Color.red);
        Debug.Log(onGround);
        if (!onGround && GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            playerAnim.SetBool("startFalling", true);
            playerAnim.SetBool("inAir", false);
        }
        if (GetComponent<Rigidbody2D>().velocity.y < 0 && Physics2D.Linecast(transform.position, transform.position + new Vector3(0, -3.5f, 0), 1 << LayerMask.NameToLayer("Land")))
        {
            playerAnim.SetBool("startFalling", false);
            playerAnim.SetBool("landed", true);

        }


        //MELEE ATTACK
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetBool("inCombat", true);
            if (Physics2D.Linecast(transform.position, transform.position + new Vector3(2.2f, 0, 0), 1 << LayerMask.NameToLayer("Enemy")))
            {
                Enemy.GetComponent<Animator>().SetBool("Hurt", true);
                Enemy.GetComponent<Animator>().SetInteger("HurtCount", HurtAnimationCount++);
                Debug.Log(HurtAnimationCount.ToString());

            }



        }
        else
            playerAnim.SetBool("inCombat", false);
        Debug.DrawLine(transform.position, transform.position + new Vector3(2.2f, 0, 0), Color.yellow);

    }

    IEnumerator WaitToJump()
    {
        yield return new WaitForSeconds(0.2f);
        Myrigid.velocity = new Vector2(Myrigid.velocity.x, myJumpStrength);

    }
    IEnumerator KillEnemy()
    {
        yield return new WaitForSeconds(1);
        Destroy(Enemy);
    }
    bool isRunning()
    {
        return playerAnim.GetBool("startRunning");

    }
}

