using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponinventory : MonoBehaviour
{
    public enum WeaponType { Pistol, Shotgun, AssaultRifle };

    public Weapon[] weapons; // Array of weapon prefabs

    // Basic Weapon class (you can expand on this based on your needs)
    public class Weapon
    {
        // Add weapon properties like damage, fire rate, etc. (optional)
    }

    private WeaponType currentWeapon;

    void Start()
    {
        currentWeapon = WeaponType.Pistol; // Start with pistol
    }

    void Update()
    {
        // Check for key presses (1, 2, or 3)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = WeaponType.Pistol;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = WeaponType.Shotgun;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = WeaponType.AssaultRifle;
        }
    }

    // Function to equip the current weapon (can be used for visuals or firing)
    public Weapon GetCurrentWeapon()
    {
        return weapons[(int)currentWeapon];
    }
}

