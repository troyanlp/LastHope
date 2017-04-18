﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrashIdleState : TrashState
{
    public TrashIdleState(GameObject go) : base(go, TrashStateTypes.IDLE_STATE)
    {
    }

    public override TrashStateTypes UpdateState()
    {
        return type;
    }
}
