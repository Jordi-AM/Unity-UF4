using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBoss : MonoBehaviour
{
    [SerializeField] GameObject explosion;
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float vel = -1;
    Animator ani;


    bool detectaPlayer = false;
    [SerializeField] LayerMask filtreCapes;

    Collider2D col;
    [SerializeField] Renderer r; // associar render del cos


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        col = GetComponent<Collider2D>();
        col.enabled = false;
        ani = GetComponentInChildren<Animator>();  // buscar un component d'un fill

    }

    private void Update()
    {
        rb.velocity = new Vector2(vel, 0);
        if (ScrControlGame.EsVisibleDesde(r, Camera.main)) col.enabled = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float radiDeteccio = 20;
        detectaPlayer = Physics2D.OverlapCircle(transform.position, radiDeteccio, filtreCapes);
        if (detectaPlayer)
        {
            ani.SetBool("atacant", true);
            vel = 0;
            // GetComponent<ScrNPCShoot>().atacant = true; // millor a Script associat a l'animator. Aquí comença a disparar i encara 
                                                        // no ha acabat la animació
        }
    }

    public void Ataca(string cosa)
    {
        GetComponent<ScrNPCShoot>().atacant = true;
        print("Atacant");
    }

    void Destruccio() // indica com es destrueix l'objecte
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}
