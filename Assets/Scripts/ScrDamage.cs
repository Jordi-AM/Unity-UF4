using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Utilitzat per determinar si l'objecte treu vida al player o als NPC
///         S'assignarà a míssils, NPC i tot allò que pugui destruir altres objectes
///         
/// AUTOR:  Jordi Aguilera
/// DATA:   19/01/2020
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: primera versió
/// ----------------------------------------------------------------------------------
/// </summary>

public class ScrDamage : MonoBehaviour
{
    public float damageNPC      = 0f; // quant mal fa a un NPC
    public float damagePlayer   = 0f; // quant mal fa al player
}
