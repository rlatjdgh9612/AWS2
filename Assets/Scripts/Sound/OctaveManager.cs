using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
public class OctaveManager : MonoBehaviour
{
    [SerializeField] OctaveChangeManager octaveChangeManager;
    [SerializeField] HorizontalSelector horizontalSelector;
    private int num;

    private void Start()
    {
        //num = GetComponent<HorizontalSelector>().index;
        num = horizontalSelector.index;
    }

    public void PreviousEvent()
    {
        num--;
        if (num < 0)
        {
            num = 0;
            return;
        }
        octaveChangeManager.OnMinusOctave();
    }

    public void ForwardEvent(int instNum)
    {
        num++;
        if (instNum < num)
        {
            num = instNum;
            return;
        }
        octaveChangeManager.OnPlusOctave();
    }
}

}
