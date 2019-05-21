using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    private Animator animator;

    int damage;

    private void Start()
    {
        animator = GetComponent<Animator>();
        damage = GetComponent<WeaponScript>().WeaponDamage;
    }

    public void PerformAttack()
    {
        animator.SetTrigger("Base_attack");
    }

    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<CharacterStats>().TakeDamage(damage);
    }
}
