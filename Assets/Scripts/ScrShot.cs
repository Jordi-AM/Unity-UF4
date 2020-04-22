using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per controlar els trets de player i enemics
/// AUTOR:  Jordi Aguilera
/// DATA:   23/12/2019
/// VERSIÓ: 0.1
/// CONTROL DE VERSIONS
///         0.1: primera versió. Desplaçament horitzontal
/// ----------------------------------------------------------------------------------
/// </summary>



public class ScrShot : MonoBehaviour
{
    [SerializeField]
    float vel = 20f;

    void Start()
    {
        Destroy(gameObject, 3); // per si no col·lisiona amb res
    }
    void Update()
    {
        transform.Translate(vel * Time.deltaTime, 0, 0);
    }

    void Destruccio() // indica com es destrueix l'objecte
    {
        Destroy(gameObject);
    }

}
