using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class move : MonoBehaviour
{
    [SerializeField] SpriteRenderer play;
    [SerializeField] bool lastFlip;
    Animator anim;
    [SerializeField] public AudioSource hurt;
    [SerializeField] public AudioSource kanan;
    [SerializeField] public AudioSource kiri;
    [SerializeField] float speed = 0.01f;
    Rigidbody2D rb;
    [SerializeField] Vector3 gerak;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D)){
            gerak.x = 1 * speed * Time.deltaTime;
            anim.SetBool("jalan", true);
            anim.SetBool("diam", false);
            lastFlip = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            lastFlip = true;
            anim.SetBool("jalan", true);
            anim.SetBool("diam", false);
            gerak.x = -1* speed * Time.deltaTime;
        }else { gerak.x = 0;
            anim.SetBool("jalan", false);
            anim.SetBool("diam", true);
        }


        flip(lastFlip);
        transform.Translate(gerak);
    }
    
    void right()
    {
        kanan.Play();
    }
    void left()
    {
        kiri.Play();
    }
     void hurtSound()
    {
        hurt.Play(0);
    }
    bool flip(bool balik)
    {
        play.flipX = balik;
        return play.flipX;
    }
    public void animasiHurt()
    {
        anim.SetTrigger("low");
    }
}
