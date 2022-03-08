using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/State Data/Charge State Data")]
public class ChargeStateData : ScriptableObject
{
    public float chargeSpeed = 6f;
    public float chargeTime = 2f;

}
