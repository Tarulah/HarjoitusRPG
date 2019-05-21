using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the stats of the player, enemies and any other character that can fight
/// </summary>

public class CharacterStats : MonoBehaviour
{
    private int Level;
    private int MaxHitPoints;
    private int HitPoints;
    private int MaxManaPoints;
    private int ManaPoints;
    private int MaxStamina;
    private int Stamina;
    private int AttackPower;
    private int Defence;
    private int Resistance;
    private int ExperienceForNextLevel;
    private int Experience;
             
    /// <summary>
    /// Initialize character stats
    /// </summary>
    /// <param name="startingLevel"></param>
    /// <param name="MaxHP"></param>
    /// <param name="MaxMP"></param>
    /// <param name="MaxSP"></param>
    public void SetCharacterStats(int startingLevel, int MaxHP, int MaxMP, int MaxSP)
    {
        Level = startingLevel;

        MaxHitPoints = MaxHP;
        MaxManaPoints = MaxMP;
        MaxStamina = MaxSP;

        HitPoints = MaxHitPoints;
        ManaPoints = MaxManaPoints;
        Stamina = MaxStamina;

        ExperienceForNextLevel = 100;
    }

    //--------------------------------/ HP /------------------------------------------------
    public void TakeDamage(int damage)
    {
        HitPoints -= damage;

        if(HitPoints <= 0)
        {
            Debug.Log("You Died!");
        }
    }

    public void HealHitPoints(int heal)
    {
        HitPoints += heal;

        if(HitPoints >= ManaPoints)
        {
            HitPoints = ManaPoints;
        }
    }

    //------------------------------/ MP /---------------------------------------------

    public void UseMana(int manaCost)
    {
        if (manaCost > ManaPoints)
        {
            //Not enough mana
            return;
        }

        ManaPoints -= manaCost;
    }

    /// <summary>
    /// Regain mana
    /// </summary>
    /// <param name="mana">How much mana is regained</param>
    public void RegainMana(int mana)
    {
        ManaPoints += mana;

        if(ManaPoints > MaxManaPoints)
        {
            ManaPoints = MaxManaPoints;
        }
    }

    //--------------------/ Stamina /------------------------------------------

    public void UseStamina(int staminaCost)
    {
        if(Stamina <= 0) 
        {
            //Not enough stamina
            return;
        }

        Stamina -= staminaCost;
    }

    /// <summary>
    /// Regain stamina
    /// </summary>
    /// <param name="stamina">How much stamina is regained</param>
    public void RegainStamina(int stamina)
    {
        Stamina += stamina;

        if(Stamina >= MaxStamina)
        {
            Stamina = MaxStamina;
        }
    }

    //-------------------------------------------------------------------------------------

    public void GainExperience(int exp)
    {
        Experience += exp;

        if(Experience >= ExperienceForNextLevel)
        {
            Level++;
            Experience -= ExperienceForNextLevel;

            //TODO: Calculate the new required exp for next level
        }
    }
}
