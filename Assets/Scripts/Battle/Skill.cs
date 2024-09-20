using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Action<Animator, Transform> OnActiveSkill = delegate {  };
    [SerializeField] private Animator hitAttackAnimator;
    [SerializeField] private Transform hitAttack;
    // Start is called before the first frame update
    [SerializeField] private float skillCoolDown = 0f;
    [SerializeField] private float skillRecovery = 1f;
    void Start()
    {
        
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
            OnActiveSkill?.Invoke(hitAttackAnimator, hitAttack);
            skillCoolDown = skillRecovery;
            
        }
    }

    public void ActiveSkill()
    {
        if (!IsSkillCoolDown()) return;
        OnActiveSkill?.Invoke(hitAttackAnimator, hitAttack);
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
