using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmScript : MonoBehaviour
{
    [Tooltip("The object which has the equipped weapon as a child")]
    public GameObject equippedWeaponObject;

    private GameObject equippedWeapon;

    // Start is called before the first frame update
    void Start()
    {
        GetEquippedWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if(equippedWeapon != null)
            {
                equippedWeapon.GetComponent<SwordScript>().PerformAttack();
            }
        }
    }

    public void GetEquippedWeapon()
    {
        //TODO: tarkista onko sitä asetta ees olemassa
        equippedWeapon = equippedWeaponObject.transform.GetChild(0).gameObject;
    }
}
