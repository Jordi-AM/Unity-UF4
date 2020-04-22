using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPoulpi : MonoBehaviour
{
    public float velX = -5f;
    Vector2 moviment = new Vector2();
    Rigidbody2D rb;

    [SerializeField] GameObject explosio;
    
    GameObject player;

    [SerializeField]
    int tipusMoviment = 1;
    float velY;

    const int QUANTS_MOVIMENTS = 5;

    Renderer r;
    Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        r = GetComponent<Renderer>();
        col = GetComponent<Collider2D>();
        col.enabled = false;
        velY = Random.Range(-3f, 3f);
        player = GameObject.FindGameObjectWithTag("Player");
        if (tipusMoviment==0) tipusMoviment = Random.Range(1, QUANTS_MOVIMENTS + 1);
    }

    void Update()
    {
        if (ScrControlGame.EsVisibleDesde(r, Camera.main))  col.enabled = true;
    }

    void FixedUpdate()
    {
        CalculaMoviment(tipusMoviment);
        rb.velocity = moviment;
    }

    void CalculaMoviment(int tipus)
    {
        switch (tipus)
        {
            case 1:  // a velocidad X
                moviment.x = velX;
                moviment.y = 0f;
                break;
            case 2:   // la mitad de velocidad que el anterior
                moviment.x = velX / 2;
                moviment.y = 0;
                break;
            case 3:
                moviment.x = velX;
                moviment.y = velY;
                break;
            case 4:  // moviment sinusoidal
                float amplitud = 4;
                float freq = 4;
                moviment.x = velX;
                moviment.y = Mathf.Sin(Time.time * freq) * amplitud;
                break;
            case 5:  // perseguint al player
                if (player) moviment.y = player.transform.position.y - transform.position.y;
                else moviment.y = 0;
                moviment.x = velX/2;
                break;

        }
    }

    void Destruccio() // indica com es destrueix l'objecte
    {
        Instantiate(explosio, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
