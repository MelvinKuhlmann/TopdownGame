﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    int ID { get; set; }
    int experience { get; set; }
    void Die();
    void TakeDamage(int amount);
    void PerformAttack();
}
