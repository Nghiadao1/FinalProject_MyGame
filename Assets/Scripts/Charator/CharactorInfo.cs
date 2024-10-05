using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterDataConFigure", menuName = "Character/CharacterDataConFigure")]
public class CharacterDataConFigure : ScriptableObject
{
    public float speed;
    public float jumpForce;
    public int health;
    public int attackPoint;
    public float distanceJump;
    public int shield;
}


[Serializable]
public class CharactorInfo : TemporaryMonoSingleton<CharactorInfo>
{
    public CharacterDataConFigure characterDataConFigure;
    public float speed;
    public float jumpForce;
    public int health;
    public int attackPoint;
    public float distanceJump;
    public int shield;
    
    private void Awake()
    {
        speed = characterDataConFigure.speed;
        jumpForce = characterDataConFigure.jumpForce;
        health = characterDataConFigure.health;
        attackPoint = characterDataConFigure.attackPoint;
        distanceJump = characterDataConFigure.distanceJump;
        shield = characterDataConFigure.shield;
    }
}

