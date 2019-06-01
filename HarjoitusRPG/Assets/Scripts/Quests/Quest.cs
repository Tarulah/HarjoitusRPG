using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quest class. Done with the help of this tutorial (series): https://www.youtube.com/watch?v=7GD5D1viVtc (1.6.2019)
/// </summary>

[System.Serializable]
public class Quest
{
    public enum QuestProgress { NOT_AVAILABLE, AVAILABLE, ACCEPTED, COMPLETED, DONE}

    public string title;                
    public int id;
    public QuestProgress progress;
    public string description;          //String from our quest giver/receiver
    public string hint;                 //String from our quest giver/receiver
    public string congratulation;       //String from our quest giver/receiver
    public string summary;              //String from our quest giver/receiver
    public int nextQuest;

    public string questObjective;
    public int questObjectiveCount;
    public int questObjectiveRequirement;

    public int expReward;
    public int goldReward;
    public string itemReward;

}
