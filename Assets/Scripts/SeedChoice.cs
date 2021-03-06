﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedChoice : MonoBehaviour
{
    EnvironmentChoice ec;
    WateringController wc;
    public List<SeedType> seeds;
    public Vector3 seedPos;

    Button[] buttons;

    private void Awake()
    {
        wc = FindObjectOfType<WateringController>();
        ec = FindObjectOfType<EnvironmentChoice>();
    }
    private void Start()
    {
        PlantSeed(PlayerPrefs.GetInt("SeedID"));
    }

    public void PlantSeed(int _ST)
    {
        if(wc != null && wc.plant!= null)
        {
            Destroy(wc.plant);
        }
        wc.plant = GetSeed(seeds[_ST]);
    }
    public GameObject GetSeed(SeedType _ST)
    {
        GameObject seedObject = new GameObject();
        seedObject.transform.position = seedPos;
        SpriteRenderer newSprite = seedObject.AddComponent<SpriteRenderer>();
        newSprite.sprite = _ST.sprites[ec.terrainID];
        seedObject.name = _ST.name;
        return seedObject;
    }
}
[System.Serializable]
public struct SeedType
{
    public string name;
    public Sprite[] sprites;
}