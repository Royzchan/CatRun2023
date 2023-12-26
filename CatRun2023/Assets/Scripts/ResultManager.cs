using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    private float _time;

    [SerializeField]
    private Text _debug;

    // Start is called before the first frame update
    void Start()
    {
        _time = GameManager._clearTime;
        _debug.text= _time.ToString()+"•b";
        Debug.Log(_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
