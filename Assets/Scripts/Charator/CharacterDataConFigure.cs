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
    //public float distanceJump;
    public int shield;
}
