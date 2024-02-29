using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class parallax1 : MonoBehaviour
{
    [SerializeField] private float speed;
    private float posAwal;
    private float posAwalZ;
    [SerializeField]private Camera cam;
    [SerializeField]private float gerakBg;
    [SerializeField]private float panjangCol;


    // Start is called before the first frame update
    void Start()
    {
        panjangCol = GetComponent<BoxCollider2D>().bounds.size.x;
        posAwal = transform.position.x;
        posAwalZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        gerakBg = cam.transform.position.x * speed;
        if (cam.transform.position.x - gerakBg > posAwal + panjangCol-3)
        {
            posAwal += panjangCol * 3- 0.3f;
        }
        if (cam.transform.position.x - gerakBg < posAwal - panjangCol-3)
        {
            posAwal -= panjangCol * 3 - 0.3f;
        }
        transform.position = new Vector3(posAwal + cam.transform.position.x,transform.position.y,posAwalZ);
    }
}
