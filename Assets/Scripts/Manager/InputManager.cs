using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public VirtualJoystick steering;

    public float fireRate = 0.2f;

    private ShipWeapons currentWeapons;

    private bool isFiring = false;

    public void SetWeapons(ShipWeapons weapons)
    {
        this.currentWeapons = weapons;
    }

    public void RemoveWeapons(ShipWeapons weapons)
    {
        if (this.currentWeapons == weapons)
        {
            this.currentWeapons = null;
        }
    }

    public void StartFiring()
    {
        StartCoroutine(FireWeapons());
    }

    IEnumerator FireWeapons()
    {
        isFiring = true;

        while (isFiring)
        {
            if (currentWeapons != null)
            {
                currentWeapons.Fire();
            }

            yield return new WaitForSeconds(fireRate);
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
