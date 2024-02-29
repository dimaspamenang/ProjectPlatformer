using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
/*using System.Numerics;*/
using UnityEngine;

public class pergerakanEnemy : MonoBehaviour
{
    CircleCollider2D col;
    [SerializeField] GameObject cols;
    [SerializeField] private float nyawa = 0;
    Animator anim;
    [SerializeField] public AudioSource hit;
    [SerializeField] public AudioSource atk;
    [SerializeField] SpriteRenderer musuh;
    [SerializeField] GameObject player;
    move move;
    [SerializeField] private float speed;
    [SerializeField] private float posNow;
    [SerializeField] private float posz;
    [SerializeField] private float jarak;
    [SerializeField] bool trig = false;
    [SerializeField] bool lastFlip;
    [SerializeField] public bool hurt = false;
    move animasi;
    // Start is called before the first frame update
    void Start()
    {

        move = player.GetComponent<move>();
        anim = GetComponent<Animator>();
        posz = player.transform.position.z;
        col = cols.GetComponent<CircleCollider2D>();
        /*player = GetComponent<GameObject>();*/
    }

    // Update is called once per frame
    void Update()
    {
        //posisi karakter di sebelah kanan musuh
        if (transform.position.x + 6 > player.transform.position.x)
        {
            
            if (transform.position.x + 3 < player.transform.position.x)
            {
                mengejar();
                print("berhenti");
                anim.SetBool("jalan", true);
                anim.SetBool("hajar", false);
                lastFlip = false;
            }
            else if (transform.position.x + 3 > player.transform.position.x)
            {
                anim.SetBool("hajar", true);
                anim.SetBool("jalan", false);
            }
        }
        else { 
            trig = false;
            anim.SetBool("hajar", false);
            anim.SetBool("jalan", false);
            
        }

        //posisi karakter di sebelah kiri musuh
        if (transform.position.x - 6 < player.transform.position.x){
            if(transform.position.x -3 > player.transform.position.x)
            {
                mengejar();
                anim.SetBool("jalan", true);
                anim.SetBool("hajar", false);
                lastFlip = true;
             }
            else if (transform.position.x - 2 < player.transform.position.x)
            {
  
                /*anim.SetBool("hajar", true);*/
                anim.SetBool("jalan", false);
            }
        }
        else { 
            trig = false;     
            anim.SetBool("jalan", false);
            anim.SetBool("hajar", false);
        }
        flip(lastFlip);

    }

     void mengejar()
     {
            Vector2 newPos = Vector2.MoveTowards(transform.position, player.transform.position, speed);
            
            transform.position = newPos;
     }

     public bool flip(bool last)
    {
        musuh.flipX = last;
        return musuh.flipX;
    }
    void hitSound()
    {
        hit.Play(0);
    }
    void soundaATK()
    {
        atk.Play(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        move.animasiHurt();
        nyawa++;
        hitSound();
    }
    
    private void colAktif()
    {
        col.enabled = true;
    }

    private void colNoAktif()
    {
        col.enabled = false;
    }
    
}