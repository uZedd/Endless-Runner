using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class Pelaaja : MonoBehaviour
{
    public float voima = 500;
    public int hyppyKorkeus = 1000;
    public bool putoaako = false;
    public GameObject UI;

    //Muuttujat äänentoistoa varten
    public AudioClip JumpSound;
    public AudioClip HitSound;
    private AudioSource Audio;
    
    

    
    public int HighScore;

    private bool canDoubleJump;
    private bool jumpOne;
    private bool jumpTwo;


    //poistetaan kuolinnäyttö alusta ja tuodaan audio komponentti muuttujaan
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        
        HighScore= PlayerPrefs.GetInt("HighScore", 0);
        jumpOne = false;
        jumpTwo = false;
        canDoubleJump = false;

    }


    //määritetään elämien ja restartin toiminta
    void Update()
    {
        

        

        

         //määritetään hyppääminen ja tuplahyppääminen 
       if(Input.GetKeyDown(KeyCode.Space)&&putoaako == false)
       {
           jumpOne = true;
           canDoubleJump = true;
           putoaako = true;

           //Hyppy-äänen toistaminen 
           Audio.PlayOneShot(JumpSound, 0.4f);
       }

       if(Input.GetKeyDown(KeyCode.Space)&&putoaako == true && canDoubleJump == true)
       {
           jumpTwo = true;
           canDoubleJump = false;;
       }
    }

    
    void FixedUpdate()
    {

        //annetaan pelaajalle voima
        transform.Translate(Vector2.right * voima * Time.deltaTime);
        
        //tuplahyppäämisen mekaniikat
        if (jumpOne == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * hyppyKorkeus);
            jumpOne = false;
        }

        if ( jumpTwo == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * hyppyKorkeus);
            jumpTwo = false;
        }
       
    }


    //laskeutuessaan pelaaja lopettaa putoamisen eikä voi tuplahypätä
    void OnCollisionStay2D (Collision2D coll)
    {
        if(coll.gameObject.tag == "Ground")
        {
            putoaako = false;
            canDoubleJump = false;
        }
    }

    //pisteenlasku ja ennätykset
    


    //kuolema
    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.gameObject.tag == "Death")
        {
            UI = GameObject.FindGameObjectWithTag("UI");
            UI.GetComponent<UIController>().TakeDamage();

            //Osuma-äänen toistaminen 
           Audio.PlayOneShot(HitSound, 1.0f);
        }
    }


    
}
