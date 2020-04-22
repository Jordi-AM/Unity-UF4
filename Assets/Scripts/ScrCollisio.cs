using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCollisio : MonoBehaviour
{


    /// <summary>
    /// ----------------------------------------------------------------------------------
    /// DESCRIPCIÓ
    ///         Script associat a Player i NPCs. Detecta col·lisions amb objectes 
    ///         enemics, mira el mal que fan, disminueixen la vida restant, i si 
    ///         arriba a 0, es destrueixen. També s'encarrega d'eliminar els trets
    /// AUTOR:  Jordi Aguilera
    /// DATA:   19/01/2020
    /// VERSIÓ: 1.0
    /// CONTROL DE VERSIONS
    ///         1.0: primera versió
    /// ----------------------------------------------------------------------------------
    /// </summary>
        
    [SerializeField]
    float vitality = 2f;
    
    [SerializeField] AudioClip tocat, enfonsat; // Inicialitzem en cada prefab

    private void OnTriggerEnter2D(Collider2D otro)
    {
        bool impacte = false;

        // print(transform.name + " vs " + otro.name); // per testejar col·lisions detectades
        ScrDamage scrD = otro.GetComponent<ScrDamage>(); // intentem llegir script ScrDamage    

        if (scrD)   // si en té, és un objecte que treu vida. Calculem
        {
            if (tag == "Player" && scrD.damagePlayer > 0)   // soc el player i l'objecte em treu vida
            {
                vitality -= scrD.damagePlayer;
                impacte = true;
            }
            else if (tag != "Player" && scrD.damageNPC > 0) // soc un NPC i l'objecte em treu vida
            {
                vitality -= scrD.damageNPC;
                impacte = true;
            }

            // si la col·lisió és amb una projectil, el destruim (busca funció Destruccio en els script associats)
            if (otro.tag == "shot")
            {
                if (tag=="Player" && scrD.damagePlayer>0 || tag!="Player" && scrD.damageNPC>0)
                otro.SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);
            }

            // si no em queda vida, m'autodestrueixo 
            if (impacte)
            {
                if (vitality <= 0)
                {
                    SendMessage("Destruccio", SendMessageOptions.DontRequireReceiver);
                    if (enfonsat) AudioSource.PlayClipAtPoint(enfonsat, Camera.main.transform.position);
                }
                else
                    if (tocat) AudioSource.PlayClipAtPoint(tocat, Camera.main.transform.position);
            }
        }
    }
}


