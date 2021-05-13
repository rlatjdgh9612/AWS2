﻿using Valve.VR;

public class SteamInputModule_Test : VRInputModule_Test
{

    public SteamVR_Input_Sources m_Source = SteamVR_Input_Sources.RightHand;
    public SteamVR_Action_Boolean m_Click = null;



    public override void Process()
    {
        base.Process();

        // Press
        if (m_Click.GetState(m_Source))
            Press();

        // Release
        if (m_Click.GetStateUp(m_Source))
            Release();
    }

}
