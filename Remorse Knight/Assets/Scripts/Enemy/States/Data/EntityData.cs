using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class EntityData : ScriptableObject
{
    public float wallCheckDistance = 0.3f;
    public float ledgeCheckDistance = 0.4f;
    public float minAggroDistance = 2f;
    public float maxAggroDistance = 4f;
    public float closeRangeActionDistance = 1f;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
