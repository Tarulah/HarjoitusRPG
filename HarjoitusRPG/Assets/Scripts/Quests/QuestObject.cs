using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An object that gives the player a quest. Can be an NPC, a billboard etc. 
/// Done with the help of this tutorial (series): https://www.youtube.com/watch?v=4oCc0btj_ys (1.6.2019)
/// </summary>

public class QuestObject : MonoBehaviour
{
    private bool inTrigger = false;

    public List<int> availableQuestIDs = new List<int>();
    public List<int> receivableQuestIDs = new List<int>();

    //TODO: Interact button
    private void Update()
    {
        if(inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Quest started");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = false;
        }
    }
}
