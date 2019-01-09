using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorting : MonoBehaviour
{

    private SpriteRenderer sr;
    private float yPos;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.sortingOrder = Mathf.RoundToInt(yPos = gameObject.transform.position.y + 100);
    }

}