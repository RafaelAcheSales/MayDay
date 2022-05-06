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
    private void Start() {
        foreach (Skill skill in GetComponentsInChildren<Skill>()) 
            skills.Add(skill.skillType, skill);
    }

    public bool IsSkillActive(Skill.SkillType skillType) {
        return skills[skillType].isActive;
    }


}
