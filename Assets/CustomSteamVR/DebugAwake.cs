using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class DebugAwake : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Behaviour_Skeleton needToAwake;

    private void Awake()
    {
        if (needToAwake == null)
        {
            needToAwake = this.GetComponent<SteamVR_Behaviour_Skeleton>();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!needToAwake.enabled)
        {
            needToAwake.enabled = true;
        }
    }
}
