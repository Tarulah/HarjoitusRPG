using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private Animator animator;

    private Collider swordHitBox;

    int damage;

    private void Start()
    {
        animator = GetComponent<Animator>();
        damage = GetComponent<WeaponScript>().WeaponDamage;

        swordHitBox = gameObject.GetComponent<Collider>();

        PlayerMovementScript.OnAttack += PerformAttack;
    }

    //void OnEquipped()
    //{
    //    PlayerMovementScript.OnAttack += PerformAttack;
    //}

    //void OnUnequip()
    //{
    //    PlayerMovementScript.OnAttack -= PerformAttack;
    //}

    public void PerformAttack()
    {
        animator.SetTrigger("Base_attack");
        swordHitBox.enabled = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        CharacterStats cs = collision.gameObject.GetComponentInParent<CharacterStats>();
        if(cs != null)
        {
            cs.TakeDamage(damage);
        }
    }
}
