using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;

    void Start()
    {
        // Schakel alle wapens uit behalve het eerste
        for (int i = 1; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }

    void FixedUpdate()
    {
        // Wapens schakelen met toetsaanslagen
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }
        // Voeg extra toetsen toe voor andere wapens indien nodig
    }

    public void SwitchWeapon(int newIndex)
    {
        // Controleer of de nieuwe index binnen de grenzen van de wapenarray valt
        if (newIndex >= 0 && newIndex < weapons.Length && weapons[newIndex] != null)
        {
            // Schakel het huidige wapen uit
            weapons[currentWeaponIndex].SetActive(false);

            // Schakel het nieuwe wapen in
            weapons[newIndex].SetActive(true);

            // Update de huidige wapenindex
            currentWeaponIndex = newIndex;
        }
        else
        {
            // Toon een debugbericht als de index buiten de arraygrenzen valt of als er geen wapen is voor de opgegeven index
            Debug.LogError("Ongeldige wapenindex of wapen niet gevonden voor index: " + newIndex);
        }
    }
}
