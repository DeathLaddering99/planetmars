using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Usage
//Firstly, populate this to a GameObject in the scene.
//Then hit the play, wait the "Set up has being done" message in console.
//Right click shoots a whole array search, left click does a dictionary search. Have a fun:) Yugata Okita 置田諭固

public class ArrayVSDictionary : MonoBehaviour
{[Tooltip("100 - 99999")]
    [SerializeField] private int sizeOfArray = 1000;
    [SerializeField] private List<Vector3> v3List = null;
    [SerializeField] private List<string> namesList = null;
    [SerializeField] private Vector3[] v3Array = null;
    [SerializeField] private string[] namesArray = null;
    [SerializeField] private Dictionary<Vector3, string> v3_NameDictionary = null;

    [SerializeField] private int arrayFindingCount = 0;
    [SerializeField] private int dictionaryFindingCount = 0;

    float currentTime = 0f;
    bool hasArraySearchStarted = false;
    bool hasDictionarySearchStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        v3List = new List<Vector3>();
        namesList = new List<string>();
        v3_NameDictionary = new Dictionary<Vector3, string>();

        for (int i = 0; i < sizeOfArray; i++)
        {
            Vector3 newV3 = new Vector3(Random.Range(0,float.MaxValue),
                Random.Range(0, float.MaxValue),Random.Range(0, float.MaxValue));

            int size = sizeOfArray / 10;
            int digit = 0;
            if (size >999)
            {
                digit = 5;
            }
            else if (size> 99)
            {
                digit = 4;
            }
            else if (size > 9)
            {
                digit = 3;
            }
            else if (size > 0)
            {
                digit = 2;
            }
            else
            {
                digit = 1;
            }

            string name = "";

            name = i.ToString("D" + digit);
            //if (digit == 0)
            //{
            //    name = i.ToString();
            //}
            //else
            //{
            //    name = i.ToString("D"+ digit);

            //}

            v3List.Add(newV3);
            namesList.Add(name);

            v3_NameDictionary.Add (newV3, name);
        }

        v3Array = new Vector3[v3List.Count];
        v3Array = v3List.ToArray();
        namesArray = new string[namesList.Count];
        namesArray = namesList.ToArray();

        Debug.Log("The set up has being done.");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hasArraySearchStarted ==false&& hasDictionarySearchStarted == false)
        {
            hasArraySearchStarted = true;
            Debug.Log("Mouse button 0 was pushed.");
            WholeArraySearch();
        }

        if (Input.GetMouseButtonDown(1) && hasDictionarySearchStarted == false && hasArraySearchStarted == false)
        {
            hasDictionarySearchStarted = true;
            Debug.Log("Mouse button 1 was pushed.");
            DictionarySearch();
        }


    }

    private void WholeArraySearch()
    {
        arrayFindingCount = 0;
        currentTime = 0f;

        currentTime = Time.realtimeSinceStartup;
        for (int i = v3Array.Length -1 ; i > -1 ; i--)
        {
            for (int k = 0; k < v3Array.Length; k++)
            {
                if (v3Array[k] == v3Array[i])
                {
                    arrayFindingCount++;
                }
            }
        }
        float nowTime = Time.realtimeSinceStartup - currentTime;
        Debug.Log("The whole array search on " + v3Array.Length.ToString() + " items for " + nowTime.ToString());
        hasArraySearchStarted = false;
    }

    private void DictionarySearch()
    {
        dictionaryFindingCount = 0;
        currentTime = 0f;
        currentTime = Time.realtimeSinceStartup;
        for (int i = v3Array.Length -1; i > -1; i--)
        {
            if (v3_NameDictionary.ContainsKey(v3Array[i]))
            {
                dictionaryFindingCount++;
            }
        }
        float nowTime = Time.realtimeSinceStartup - currentTime;
        Debug.Log("The dictionary  key search on " + v3Array.Length.ToString() + " items for " + nowTime.ToString());
        hasDictionarySearchStarted = false;
    }
} 
