﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITeleportable
{
    void DoTeleport(BaseUnit target, Transform place);
}
