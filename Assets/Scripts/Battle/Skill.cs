using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Action<Animator, Transform, int> OnActiveSkill = delegate {  };
    [SerializeField] private Animator hitAttackAnimator;
    [SerializeField] private Transform hitAttack;
    [SerializeField] private int skillStrength = 2;
    // Start is called before the first frame update
    [SerializeField] private float skillCoolDown = 0f;
    [SerializeField] private float skillRecovery = 1f;
    void OnEnable()
    {
        CharactorControl.OnSkill += ActiveSkill;
    }
    void OnDisable()
    {
        CharactorControl.OnSkill -= ActiveSkill;
    }
    

    // Update is called once per frame
    void Update()
    {
        ActiveSkillByKeyBoard();
    }

    private void FixedUpdate()
    {
        SkillCoolDown();
    }

    private void ActiveSkillByKeyBoard()
    {
        if (Input.GetKeyDown(KeyCode.D) && IsSkillCoolDown())
        {
            OnActiveSkill?.Invoke(hitAttackAnimator, hitAttack, skillStrength);
            skillCoolDown = skillRecovery;
            
        }
    }

    public void ActiveSkill(bool isSkill)
    {
        if (!IsSkillCoolDown()) return;
        if (!isSkill) return;
        OnActiveSkill?.Invoke(hitAttackAnimator, hitAttack, skillStrength);
        skillCoolDown = skillRecovery;
    }
    private void SkillCoolDown()
    {
        if (skillCoolDown > 0)
        {
            skillCoolDown -= Time.deltaTime;
        }
    }

    private bool IsSkillCoolDown()
    {
        return skillCoolDown <= 0;
    }
    
}
