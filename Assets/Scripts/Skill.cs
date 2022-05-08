using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]
public class Skill : MonoBehaviour
{
    public enum SkillType
    {
        MoveSpeed,
        DoubleJump,
        Dash,
        Glide,
        Shield,
        WallGrab,
    }
    public enum SkillState {
        Locked,
        Unlocked,
        Active,
    }

    public SkillType skillType;
    public SkillState skillState;
    public UnityEvent<SkillType> onSkillActivate;
    public string skillDetails;
    

    public bool isActive { get { return skillState == SkillState.Active; } }

    private SpriteRenderer spriteRenderer;
    private Text skillDetailsText;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        skillDetailsText = GameObject.Find("SkillDetails").GetComponent<Text>();
        UpdateColor();

    }

    public Skill GetUpwardSkill()
    {
        transform.parent.TryGetComponent<Skill>(out Skill skill);
        return skill;
    }

    public List<Skill> GetDownwardSkills()
    {
        List<Skill> skills = new List<Skill>();
        foreach(Transform child in transform)
        {
            child.TryGetComponent<Skill>(out Skill skill);
            if (skill != null)
                skills.Add(skill);
        }
        return skills;
    }
    public void UpdateColor(){
        switch (skillState)
        {
            case SkillState.Locked:
                spriteRenderer.color = SkillsManager.Instance.lockedColor;
                break;
            case SkillState.Unlocked:
                spriteRenderer.color = SkillsManager.Instance.unlockedColor;
                break;
            case SkillState.Active:
                spriteRenderer.color = SkillsManager.Instance.activeColor;
                break;
        }
    }

    public void Unlock()
    {
        skillState = SkillState.Unlocked;
        UpdateColor();
        Debug.Log("Unlocked " + skillType);

    }

    public void Activate()
    {
        skillState = SkillState.Active;
        onSkillActivate.Invoke(skillType);
        UpdateColor();
        SkillsManager.Instance.audioSource.Play();
        foreach (Skill skill in GetDownwardSkills())
            if (skill.skillState == SkillState.Locked)
                skill.Unlock();
        Debug.Log("Activated " + skillType);
        
    }
    private void OnMouseDown() {
        if (SkillsManager.Instance.skillPoints <= 0) return;
        if (skillState != SkillState.Unlocked) return;
        SkillsManager.Instance.skillPoints--;
        Activate();
    }

    private void OnMouseEnter() {
        skillDetailsText.text = skillDetails;
        skillDetailsText.enabled = true;
    }

    private void OnMouseExit() {
        skillDetailsText.enabled = false;
        skillDetailsText.text = "";
    }


}
