using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GetMat : MonoBehaviour
{
    FCP_ExampleScript change;
    public int i;
    private void Awake()
    {
        change = GetComponent<FCP_ExampleScript>();
    }

    private void Update()
    {
        RemoveIndex();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Touch Object의 Mat를 List로 추가하고 이미 List에 추가된 상태라면 삭제한다.
        if (change.materials.Contains(other.gameObject.GetComponent<Renderer>().material))
        {
            i = change.materials.IndexOf(other.gameObject.GetComponent<Renderer>().material);
            change.materials.RemoveAt(i);
        }
        else
            change.materials.Add(other.gameObject.GetComponent<Renderer>().material);
    }

    void RemoveIndex()
    {
        // List에 원소를 모두 제거 ( 선택된 그룹을 취소 )
        if (Input.GetKeyDown(KeyCode.A))
            change.materials.RemoveRange(0, change.materials.Count);
    }
}
