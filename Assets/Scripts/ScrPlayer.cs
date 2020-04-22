using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar el player
/// AUTOR:  Jordi Aguilera
/// DATA:   23/12/19
/// VERSIÓ: 0.1
/// CONTROL DE VERSIONS
///         0.1: Moviment de la nau amb tecles i físiques
/// ----------------------------------------------------------------------------------
/// </summary>



public class ScrPlayer : MonoBehaviour
{
    
    float velocitat = 10f;   // velocitat de la nau
    [SerializeField]  float cadencia = 0.5f; // dispararà cada 5 dècimes de segon


    [SerializeField]
    Transform missil; // element a instanciar. Arrosseguem prefab!
    [SerializeField]
    Transform[] canons;    // d'on surt el tret

    Vector2 movi = new Vector2();   // per calcular moviment
    Rigidbody2D rb;                 // per accedir al component RigidBody

    AudioSource sonido;


    float crono = 0f;	  // per comptar el temps de cadència

    float timePowerUp = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Damos valor a rb
        sonido = GetComponent<AudioSource>();

    }

    void Update()
    {
        movi.x = ETCInput.GetAxis("Horizontal") * velocitat;  // Llegim entrada teclat
        movi.y = ETCInput.GetAxis("Vertical") * velocitat;
        if (ETCInput.GetButton("Shoot") && crono <= 0) Dispara();
        crono -= Time.deltaTime;
        // la següent línea permet disparar ràpid amb múltiples clicks
        if (ETCInput.GetButtonUp("Shoot")) crono = 0f;

        if (Input.GetKeyDown(KeyCode.E))
        {
            SetExtraMissils(true);
            timePowerUp = 5;
        }
        if (timePowerUp > 0) timePowerUp -= Time.deltaTime; else SetExtraMissils(false);


    }

    void FixedUpdate()
    {
        rb.velocity = movi;     // Apliquem velocitat. No utilitzar Translate (fisiques!)
    }

    void Dispara()
    {
        crono = cadencia;
        foreach (Transform c in canons)
            if (c.gameObject.activeSelf) Instantiate(missil, c.position, c.rotation);
        sonido.Play();
    }

    void SetExtraMissils(bool estat)
    {
        canons[0].gameObject.SetActive(estat);
        canons[2].gameObject.SetActive(estat);
    }

    void Destruccio() // indica com es destrueix l'objecte
    {
        Destroy(gameObject);
    }

}
