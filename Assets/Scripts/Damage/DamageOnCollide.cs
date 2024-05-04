using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage = 1;

    // damage when we hit something
    public int damageToSelf = 5;

    void HitObject(GameObject theObject)
    {
        //damage to the thing
        var theirDamage = theObject.GetComponentInParent<DamageTaking>();
        if (theirDamage)
        {
            theirDamage.TakeDamage(damage);
        }

        //damage to ourself
        var ourDamage = this.GetComponentInParent<DamageTaking>();
        if (ourDamage)
        {
            ourDamage.TakeDamage(damageToSelf);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.transform.parent.parent.CompareTag("Station"))
        {
            HitObject(collider.gameObject);

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        
        HitObject(collision.gameObject);
    }
}
