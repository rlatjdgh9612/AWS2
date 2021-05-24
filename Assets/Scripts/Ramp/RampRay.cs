using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (AudioSource))]
public class RampRay : MonoBehaviour
{
    private bool isOne = false;
    GameObject soundInfo;
    private float dist;
    private float multDist;
    [SerializeField] private Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRay();
    }

    void UpdateRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue))
        {
            if (hit.transform.gameObject.GetComponent<AudioSource>() != null)
            {
                if (hit.transform.gameObject.GetComponent<AudioSource>().clip != null)
                {
                    if (hit.transform.gameObject.CompareTag("Pad"))
                    {
                        char divide = '_';
                        string[] split = hit.transform.gameObject.GetComponent<AudioSource>().clip.name.Split(divide);
                        string name1 = split[split.Length - 2];
                        string name2 = Parsing(split.Last(), name1);
                        string fullName = name1 + "_" + name2;

                        if (!isOne)
                        {
                            soundInfo = Load("SoundInfo/SoundInfo");
                            isOne = true;
                        }

                        dist = Vector3.Distance(transform.position, hit.point);
                        multDist = Mathf.Pow(dist * 2.0f, 5.0f);

                        soundInfo.GetComponentInChildren<Text>().text = fullName;
                        soundInfo.GetComponentInChildren<Text>().color = new Color(1.0f, 1.0f, 1.0f, ((255.0f/multDist)/255.0f)*2);
                        soundInfo.GetComponentInChildren<Image>().color = new Color(0.0f,225.0f/255.0f,1.0f,((255.0f/multDist)/255.0f)*2);
                        soundInfo.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z) + (Vector3.up * 0.1f);
                        soundInfo.transform.rotation = Quaternion.Euler(soundInfo.transform.eulerAngles.x, playerCam.transform.eulerAngles.y, soundInfo.transform.eulerAngles.z);
                    }
                    else
                    {
                        if (isOne)
                        {
                            soundInfo.GetComponentInChildren<Image>().color = new Color(0.0f,225.0f/255.0f,1.0f,0.0f);
                            Destroy(soundInfo);
                        }
                        isOne = false;
                    }
                }
            }
        }
    }

    string Parsing(string soundName, string soundCode)
    {
        if (soundCode == "C1" || soundCode == "C2" || soundCode == "C3" || soundCode == "C4" || soundCode == "C5")
        {
            if (soundName == "01")
            {
                return "도";
            }else if (soundName == "02")
            {
                return "도#";
            }else if (soundName == "03")
            {
                return "레";
            }else if (soundName == "04")
            {
                return "레#";
            }else if (soundName == "05")
            {
                return "미";
            }else if (soundName == "06")
            {
                return "파";
            }else if (soundName == "07")
            {
                return "파#";
            }else if (soundName == "08")
            {
                return "솔";
            }else if (soundName == "09")
            {
                return "솔#";
            }else if (soundName == "10")
            {
                return "라";
            }else if (soundName == "11")
            {
                return "라#";
            }else if (soundName == "12")
            {
                return "시";
            }
            else
            {
                return soundName;
            }
        }else if (soundCode == "Drum")
        {
            if (soundName == "Crash")
            {
                return "크래쉬";
            }else if (soundName == "HandClap")
            {
                return "핸드클랩";
            }else if (soundName == "HiHat(Close)")
            {
                return "하이헷(닫힘)";
            }else if (soundName == "HiTom")
            {
                return "하이탐";
            }else if (soundName == "Kick")
            {
                return "킥";
            }else if (soundName == "MidTom")
            {
                return "미드탐";
            }else if (soundName == "RideEdge")
            {
                return "라이드엣지";
            }else if (soundName == "Shaker")
            {
                return "쉐이커";
            }else if (soundName == "Snare")
            {
                return "스네어";
            }else if (soundName == "Tambourine")
            {
                return "탬버린";
            }
            else
            {
                return soundName;
            }
        }else if (soundCode == "Conga")
        {
            if (soundName == "BassTone")
            {
                return "베이스톤";
            }else if (soundName == "CloseSlap")
            {
                return "클로즈슬랩";
            }else if (soundName == "FloatingFinger")
            {
                return "플로팅핑거";
            }else if (soundName == "FloatingHeel")
            {
                return "플로팅힐";
            }else if (soundName == "MuffledSlap")
            {
                return "머플슬랩";
            }else if (soundName == "OffCenter")
            {
                return "오프센터";
            }else if (soundName == "OpenSlap")
            {
                return "오픈슬랩";
            }else if (soundName == "OpenTone")
            {
                return "오픈톤";
            }else if (soundName == "Rim")
            {
                return "림";
            }
            else
            {
                return soundName;
            }
        }
        else
        {
            return soundName;
        }
    }

    GameObject Load(string resourcePath)
    {
        GameObject go = null;

        go = Resources.Load<GameObject>(resourcePath);

        if (!go)
        {
            Debug.Log("Resources Load Error FilePath = " + resourcePath);
            return null;
        }

        GameObject InstantiateGo = Instantiate<GameObject>(go);
        return InstantiateGo;
    }
}
