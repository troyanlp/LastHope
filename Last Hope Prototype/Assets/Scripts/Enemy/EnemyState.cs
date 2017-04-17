﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum TrashStateTypes
{
    IDLE_STATE,
    ATTACK_STATE,
    DEAD_STATE,
    DAMAGED_STATE,
    CHASE_STATE,
    COMBAT_STATE,
    UNDEFINED_STATE
}

public class EnemyState
{
    protected TrashStateTypes type;
    protected int numberOfFrames = 0;


    public EnemyState(TrashStateTypes type)
    {
        this.type = type;
    }
}

