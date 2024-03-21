using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public Shooting shootingScript;

    void Start()
    {
        // Zet het schiet-script in de inspector
        if (shootingScript == null)
        {
            Debug.LogError("Geen schiet-script toegewezen aan WeaponSwitching!");
            enabled = false; // Schakel het script uit als er geen schiet-script is toegewezen
            return;
        }

        // Stel het standaardwapen in op pistool
        shootingScript.isPistol = true;
        shootingScript.isShotgun = false;
        shootingScript.isAssaultRifle = false;
    }

    void Update()
    {
        // Wapens schakelen met toetsaanslagen
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(true, false, false); // Pistool
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(false, true, false); // Shotgun
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(false, false, true); // Assault Rifle
        }
        // Voeg extra toetsen toe voor andere wapens indien nodig

        // Pistool afvuren wanneer de muisknop wordt losgelaten
        if (shootingScript.isPistol && Input.GetMouseButtonDown(0))
        {
            shootingScript.FirePistol();
        }

        // Shotgun afvuren wanneer de muisknop wordt losgelaten
        if (shootingScript.isShotgun && Input.GetMouseButtonDown(0))
        {
            shootingScript.FireShotgun();
        }
    }

    void SetWeapon(bool pistol, bool shotgun, bool assaultRifle)
    {
        // Zet de wapenstatussen in het schiet-script
        shootingScript.isPistol = pistol;
        shootingScript.isShotgun = shotgun;
        shootingScript.isAssaultRifle = assaultRifle;
    }
}

