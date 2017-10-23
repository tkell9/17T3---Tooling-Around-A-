using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OneShotData
{
    public ClipNames name;
}

public class UnityEventPlayOneShot : UnityEvent<OneShotData> { }

public class SpeedChangedData
{
    public Vector3 newSpeed;
}

public class UnityEventSpeedChanged : UnityEvent<SpeedChangedData> { }

public static class GlobalEvents  {
    public static UnityEventPlayOneShot playOneShot = new UnityEventPlayOneShot();
    public static UnityEventSpeedChanged speedChanged = new UnityEventSpeedChanged();
}
