﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorting : MonoBehaviour
{

    private SpriteRenderer sr;
    private float yPos;
    public GameObject sortingLayerTool;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        sr.sortingOrder = Mathf.RoundToInt(yPos = (sortingLayerTool.transform.position.y * -1)+100);
    }

}