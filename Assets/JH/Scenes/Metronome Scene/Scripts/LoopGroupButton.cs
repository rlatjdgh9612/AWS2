using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGroupButton : MonoBehaviour
{
    public RecordPlayer rp;

    public bool isLoop;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Controller")
            rp.OnClickPlay(isLoop);
    }
}
