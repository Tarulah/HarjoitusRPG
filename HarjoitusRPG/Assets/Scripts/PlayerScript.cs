using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int PlayerStartingLevel;
    public int MaxPlayerHP;
    public int MaxPlayerMana;
    public int MaxPlayerStamina;

    /// <summary>
    /// CharacterStats cs
    /// </summary>
    private CharacterStats cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = gameObject.GetComponent<CharacterStats>();
        //Initialize player stats
        cs.SetCharacterStats(PlayerStartingLevel, MaxPlayerHP, MaxPlayerMana, MaxPlayerStamina);
    }
}
