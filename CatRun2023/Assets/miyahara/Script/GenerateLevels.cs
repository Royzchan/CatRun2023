using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevels : MonoBehaviour
{
    public GameObject[] level;
    public int xPos = 12;
    public bool creatingLevel = false;
    public int lvlNum;
    public bool set = true;
    public GameObject Goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!creatingLevel)
        {
            if (set == true)
            {
                creatingLevel = true;
                StartCoroutine(GenerateLvl());
            }

        }
    }

    IEnumerator GenerateLvl()
    {
        lvlNum = Random.Range(0, 4); // 0, 1, 2, 3
        Instantiate(level[lvlNum], new Vector3(xPos, 0, 0), Quaternion.identity);
        xPos += 80;
        yield return new WaitForSeconds(3);
        creatingLevel = false;
        if(xPos > 150)
        {
            set = false;
            Instantiate(Goal, new Vector3(xPos,0, 0), Quaternion.identity);
        }
    }
}