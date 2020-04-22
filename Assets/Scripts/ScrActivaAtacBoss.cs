using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrActivaAtacBoss : MonoBehaviour
{

    public void ActivaAtac()
    {
        GetComponentInParent<ScrNPCShoot>().atacant = true;
    }
}
