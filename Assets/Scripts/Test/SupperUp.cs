using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupperUp : TemporaryMonoSingleton<SupperUp>
{
    public int supper = 10;

    public void SuperDown()
    {
        supper = -10;
    }
}
