using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int PlayerStartingLevel;
    public int MaxPlayerHP;
    public int MaxPlayerMana;
    public int MaxPlayerStamina;

    [Tooltip("The slot where the equiped game object is as a child")]
    public GameObject EquippedWeaponSlot;

    [HideInInspector]
    public GameObject EquippedWeapon;

    private CharacterStats cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = gameObject.GetComponent<CharacterStats>();
        //Initialize player stats
        cs.SetCharacterStats(PlayerStartingLevel, MaxPlayerHP, MaxPlayerMana, MaxPlayerStamina);
    }
}
