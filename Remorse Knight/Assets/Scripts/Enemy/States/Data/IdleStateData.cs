using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newIdleStateData", menuName = "Data/IdleStateData/Idle State")]

public class IdleStateData : ScriptableObject
{
    public float minIdleTime = 1f;
    public float maxIdleTime = 2f;
}
