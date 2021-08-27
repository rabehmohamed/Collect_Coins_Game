using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
    

{
    public float speed = 5;
    public float horizontalInput;
    public float turnspeed = 5;
    public float verticalInput;
    public float leftX = 1.40f;
    public float rightlimit = -1.40f;
    private Rigidbody playerrg;
    private Animator playeranm;
    public bool onGround = true;
    public bool gameover = false;
    public bool forword;
    private AudioSource playerAudio;
    public AudioClip jump;
    public AudioClip crash;
    public GameManage script;

    // Start is called before the first frame update
    void Start()
    {
        playerrg = GetComponent<Rigidbody>();
        playeranm = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        script = GameObject.Find("gamer").GetComponent<GameManage>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameover == false)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                forword = false;
                playeranm.SetFloat("Speed_f", 0.0f);
            }
         
            if (Input.GetKeyDown(KeyCode.W))
            {
                forword = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                forword = true;
            }
            if (forword == true)
            {
                playeranm.SetBool("Static_b", true);
                playeranm.SetFloat("Speed_f", 1.0f);
                verticalInput = Input.GetAxis("Vertical");
                transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            }
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * turnspeed * horizontalInput);

            if (transform.position.x < -1.40)
            {
                transform.position = new Vector3(rightlimit, transform.position.y, transform.position.z);
            }
            if (transform.position.x > 1.40)
            {
                transform.position = new Vector3(leftX, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                playeranm.SetTrigger("Jump_trig");
                playerrg.AddForce(Vector3.up * 6, ForceMode.Impulse);
                playerAudio.PlayOneShot(jump, 1);
                onGround = false;
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            onGround = true;
        }
        if (collision.gameObject.CompareTag("obstacle")) {
            playerAudio.PlayOneShot(crash, 2);
            Debug.Log("GameOver");
            gameover = true;
            playeranm.SetBool("Death_b", true);
            playeranm.SetInteger("DeathType_int", 1);
            script.GameOver();
        }
        if(collision.gameObject.CompareTag("coin"))
        {
            
        }
        
    }
}
     

