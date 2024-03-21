using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponinventory : MonoBehaviour
{
    public Shooting shooting;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            shooting.isPistol = true;
            shooting.isShotgun = false;
            shooting.isAssaultRifle = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shooting.isPistol = false;
            shooting.isShotgun = true;
            shooting.isAssaultRifle = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            shooting.isPistol = false;
            shooting.isShotgun = false;
            shooting.isAssaultRifle = true;
        }
    }
}

