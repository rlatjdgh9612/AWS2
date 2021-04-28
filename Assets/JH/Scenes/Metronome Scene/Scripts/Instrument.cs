using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Instrument : MonoBehaviour
{
    public GameObject instrument;
    public Record record;
    public InstrumentPad[] padList;

    private void Start()
    {
        padList = gameObject.GetComponentsInChildren<InstrumentPad>();
        padList = padList.OrderBy(p => p.name).ToArray();
        if (record != null)
            record.padCount = padList.Length;

        for (int i = 0; i < padList.Length; i++)
        {
            padList[i].padIndex = i;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Recorder")
        {
            if (record != null)
                record.padCount = padList.Length;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Recorder")
            record = null;
    }
}
