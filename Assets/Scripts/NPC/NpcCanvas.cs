using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcCanvas : MonoBehaviour
{
    [Header("NPC")]
    public TMP_Text npcName;

    [Header("Quest Icon")]
    public Image questIcon;
    public Sprite newQuest;
    public Sprite questComplete;

    public void SetNpcName(string name)
    {
        npcName.text = name;
    }

    public void SetQuestIconVisible(bool value)
    {
        questIcon.gameObject.SetActive(value);
    }

    public void SetQuestIconToQuestComplete()
    {
        questIcon.sprite = questComplete;
    }

    public void SetQuestIconToNewQuest()
    {
        questIcon.sprite = newQuest;
    }
}
