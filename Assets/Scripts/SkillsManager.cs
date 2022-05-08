using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : Singleton<SkillsManager>
{
    public Dictionary<Skill.SkillType, Skill> skills = new Dictionary<Skill.SkillType, Skill>();
    public int skillPoints = 0;

    public Color lockedColor;
    public Color unlockedColor;
    public Color activeColor;
    public AudioSource audioSource;
    private void Start() {
        foreach (Skill skill in GetComponentsInChildren<Skill>()) 
            skills.Add(skill.skillType, skill);
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsSkillActive(Skill.SkillType skillType) {
        return skills[skillType].isActive;
    }
    public void AddSkillPoints(int points) {
        skillPoints += points;
    }


}
