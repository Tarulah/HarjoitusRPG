using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Quest class. Done with the help of this tutorial (series): https://www.youtube.com/watch?v=4oCc0btj_ysd (1.6.2019)
/// </summary>

public class QuestManager : MonoBehaviour
{
    public static QuestManager questManager;

    public List<Quest> questList = new List<Quest>();
    public List<Quest> currentQuests = new List<Quest>();

    private void Awake()
    {
        if(questManager == null)
        {
            questManager = this;
        }
        else if(questManager != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void QuestRequest(QuestObject questObject)
    {
        //AVAILABLE QUESTS
        if(questObject.availableQuestIDs.Count > 0)
        {
            for (int i = 0; i < questList.Count; i++)
            {
                for (int j = 0; j < questObject.availableQuestIDs.Count; j++)
                {
                    if(questList[i].id == questObject.availableQuestIDs[j] && questList[i].progress == Quest.QuestProgress.AVAILABLE)
                    {
                        Debug.Log("Quest ID: " + questObject.availableQuestIDs[j] + " " + questList[i].progress);

                        AcceptQuest(questObject.availableQuestIDs[j]);
                    }
                }
            }
        }

        //ACTIVE QUESTS
        for (int i = 0; i < currentQuests.Count; i++)
        {
            for (int j = 0; j < questObject.receivableQuestIDs.Count; j++)
            {
                if(currentQuests[i].id == questObject.receivableQuestIDs[j] && currentQuests[i].progress == Quest.QuestProgress.ACCEPTED || currentQuests[i].progress == Quest.QuestProgress.COMPLETED)
                {
                    Debug.Log("Quest ID: " + questObject.receivableQuestIDs[j] + " is " + currentQuests[i].progress);

                    CompleteQuest(questObject.receivableQuestIDs[j]);
                }
            }
        }
    }


    //ACCEPT QUEST
    public  void AcceptQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                currentQuests.Add(questList[i]);
                questList[i].progress = Quest.QuestProgress.ACCEPTED;

                Debug.Log("Quest accepted.");
            }
        }
    }

    //GIVE IP QUEST
    public void GiveUpQuest(int questID)
    {
        for (int i = 0; i < currentQuests.Count; i++)
        {
            if (currentQuests[i].id == questID && currentQuests[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuests[i].progress = Quest.QuestProgress.AVAILABLE;
                currentQuests[i].questObjectiveCount = 0;

                Debug.Log("Quest given up.");

                currentQuests.Remove(questList[i]);
            }
        }
    }

    //COMPLETE QUEST
    public void CompleteQuest(int questID)
    {
        for (int i = 0; i < currentQuests.Count; i++)
        {
            if(currentQuests[i].id == questID && currentQuests[i].progress == Quest.QuestProgress.COMPLETED)
            {

                Debug.Log("Quest done.");
                currentQuests[i].progress = Quest.QuestProgress.DONE;
                currentQuests.Remove(currentQuests[i]);
            }
        }
    }

    //ADD ITEM
    public void AddQuestItem(string QuestObjective, int itemAmount)
    {
        for (int i = 0; i < currentQuests.Count; i++)
        {
            if(currentQuests[i].questObjective == QuestObjective && currentQuests[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                currentQuests[i].questObjectiveCount += itemAmount;
            }

            if(currentQuests[i].questObjectiveCount >= currentQuests[i].questObjectiveRequirement && currentQuests[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                Debug.Log("Quest completed.");
                currentQuests[i].progress = Quest.QuestProgress.COMPLETED;
            }
        }
    }




    /// <summary>
    /// Is a particular quest available to the player
    /// </summary>
    /// <param name="questID">The id of a particular quest</param>
    /// <returns>True if the quest is available, otherwise false</returns>
    public bool IsQuestAvailable(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progress == Quest.QuestProgress.AVAILABLE)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Has the player accepted a particular quest
    /// </summary>
    /// <param name="questID">The id of a particular quest</param>
    /// <returns>True if the quest is accepted, otherwise false</returns>
    public bool IsQuestAccepted(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.ACCEPTED)
            {
                return true;
            }
        }

        return false;
    }


    /// <summary>
    /// Has player completed the quest but not yet gotten the reward for it
    /// </summary>
    /// <param name="questID">The id of a particular quest</param>
    /// <returns>True if the quest is accepted, otherwise false</returns>
    public bool IsQuestCompleted(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progress == Quest.QuestProgress.COMPLETED)
            {
                return true;
            }
        }

        return false;
    }


}
