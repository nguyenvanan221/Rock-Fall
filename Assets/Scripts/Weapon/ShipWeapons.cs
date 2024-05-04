using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public Transform[] firePoints;

    private int firePointIndex;

    public void Awake()
    {
        InputManager.Instance.SetWeapons(this);
    }

    //public void OnDestroy()
    //{
    //    if (Application.isPlaying == true)
    //    {
    //        error
    //        InputManager.Instance.RemoveWeapons(this);
    //    }
    //}

    public void Fire()
    {
        
        if (firePoints.Length == 0)
        {
            return;
        }
        var firePointToUse = firePoints[firePointIndex];

        GameObject shot = ObjectPool.Instance.GetPooledObject();
        if (shot != null)
        {
            shot.transform.position = firePointToUse.transform.position;
            shot.transform.rotation = firePointToUse.transform.rotation;
            shot.SetActive(true);
        }


        //audio
        var audio = firePointToUse.GetComponent<AudioSource>();
        if (audio)
        {
            audio.Play();
        }

        firePointIndex++;

        if (firePointIndex >= firePoints.Length)
        {
            firePointIndex = 0;
        }
    }
}
