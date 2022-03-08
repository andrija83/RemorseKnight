using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyMeleAttackStateData", menuName = "Data/State Data/Enemy Mele Attack State Data")]

public class EnemyMeleAttackStateData : ScriptableObject
{
    public float attackRadius = 0.5f;
    public LayerMask whatIsPlayer;
    public float attackDamage = 10;
}
