using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTimer : MonoBehaviour
{

    public float time;
    public GameObject activeObject;

    void Start()
    {
        StartCoroutine(Timer());
        activeObject.SetActive(false);
    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        activeObject.SetActive(true);
    }

}
