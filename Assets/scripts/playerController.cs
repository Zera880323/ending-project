using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    private Rigidbody playerrb;
    private Animator playerani;
    private AudioSource playeraud;

    public ParticleSystem runParticle;
    public ParticleSystem deathParticle;

    public AudioClip jumpClip;
    public AudioClip deathClip;

    public int upforce = 100;
    public bool isOnGround = true; // on ground
    public float gravityoffset = 3f;
    public bool gameover = false;
    // Start is called before the first frame update
    void Start()
    {
        playerrb = GetComponent<Rigidbody>();
        playerani = GetComponent<Animator>();
        playeraud = GetComponent<AudioSource>();

        Physics.gravity *= gravityoffset; //Physics.gravity = Physics.gravity * gravityoffset; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerrb.AddForce(Vector3.up * upforce, ForceMode.Impulse);
            isOnGround = false; // not on ground
            playerani.SetTrigger("Jump_trig");
            runParticle.Stop();
            playeraud.PlayOneShot(jumpClip);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isOnGround = true; // on ground
            runParticle.Play();
        }
        else if (collision.gameObject.CompareTag("ob"))
        {
            gameover = true;
            playerani.SetBool("Death_b", true);
            playerani.SetInteger("DeathType_int", 1);
            runParticle.Stop();
            deathParticle.Play();
            playeraud.PlayOneShot(deathClip);
            Debug.Log("Game over)");
        }
    }
}