using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterData : TemporaryMonoSingleton<CharaterData>
{
    public Upgrade upgrade;
    public float speed;
    public float jumpForce;
}
