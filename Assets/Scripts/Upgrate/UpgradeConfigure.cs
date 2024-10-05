using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UpgradeConfigure", menuName = "Upgrade/UpgradeConfigure")]
public class UpgradeConfigure : ScriptableObject
{
    public Upgrade[] upgrades;
}
[Serializable]
public class Upgrade
{
    public UpgradeType upgradeType;
    public int price;
    public int value;
    public int data;
}
public enum UpgradeType
{
    speed,
    jumpForce,
    attackPoint,
    DEF,
    health,
    distanceJump
}
