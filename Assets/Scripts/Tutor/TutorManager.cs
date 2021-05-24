using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TutorData
{
    public string tutorCategory;
    public Transform tutorParent;
    public int tutorCacheCount;
    public List<Sprite> tutorImage = new List<Sprite>();
    public List<string> tutorVideoPath = new List<string>();
}

public class TutorManager : MonoBehaviour
{
    [SerializeField] private static TutorManager instance = null;
    public static TutorManager Instance => instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("SingleTone Error!");
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    [SerializeField] private TutorFactory tutorFactory;
    [SerializeField] private string tutorPrefabPath;
    [SerializeField] private string tutorPath;
    [SerializeField] private TutorData[] tutorData;
    [SerializeField] Dictionary<string, Queue<GameObject>> tutors = new Dictionary<string, Queue<GameObject>>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tutorData.Length; i++)
        {
            string _tutorCategory = tutorData[i].tutorCategory;
            Transform _tutorParent = tutorData[i].tutorParent;
            int _tutorCacheCount = tutorData[i].tutorCacheCount;
            List<Sprite> _tutorImage = tutorData[i].tutorImage;
            List<string> _tutorVideoPath = tutorData[i].tutorVideoPath;

            GenerateTutor(_tutorCategory, _tutorParent, _tutorCacheCount, _tutorImage, _tutorVideoPath);
        }
    }

    public bool GenerateTutor(string tutorCategory, Transform tutorParent, int tutorCacheCount, List<Sprite> tutorImage,
        List<string> tutorVideoPath)
    {
        if (tutors.ContainsKey(tutorCategory))
        {
            Debug.LogWarning("Already TutorCategory Instantiate tutor = " + tutorCategory);
            return false;
        }
        else
        {
            Queue<GameObject> queue = new Queue<GameObject>();

            for (int i = 0; i < tutorCacheCount; i++)
            {
                GameObject go = tutorFactory.Load(tutorPrefabPath);

                if (!go)
                {
                    Debug.LogError("tutor Prefab Load Error = " + tutorPrefabPath);
                    return false;
                }
                
                go.transform.SetParent(tutorParent);
                go.transform.localScale = Vector3.one;
                go.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
                go.transform.localRotation = Quaternion.Euler(Vector3.zero);
                go.GetComponent<Image>().sprite = tutorImage[i];
                char divide = '/';
                string[] split = tutorVideoPath[i].Split(divide);
                go.name = split.Last();
                go.GetComponentInChildren<Text>().text = split.Last();
                go.GetComponent<TutorMenu>().TutorPath = tutorPath;
                go.GetComponent<TutorMenu>().TutorVideoPath = tutorVideoPath[i];
                
                queue.Enqueue(go);
            }
            
            tutors.Add(tutorCategory, queue);
        }

        return true;
    }
}
