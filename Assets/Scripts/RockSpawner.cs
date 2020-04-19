﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

[Serializable]public class RockSpawn {
    public enum rocks {
        Normal,
        Light, 
        Heavy,
        LowGrav,
        ReverseGrav,
        Bouncey
    }

    public rocks spawnObject;
    public int spawns;
    public float delay;
}

public class RockSpawner : MonoBehaviour {

    public GameObject[] rocks;
    public RockSpawn[] eventSystem;
    public static int TotalSpawns;
    
    void Start() {
        GameState.Instance.OnGameStart += StartPlaying;
        TotalSpawns = eventSystem.Sum(spawn => spawn.spawns);
    }

    void StartPlaying() {
        foreach(RockSpawn rock in eventSystem)
            StartCoroutine(wait(rock.delay, rocks[(int) rock.spawnObject], rock.spawns));
    }

    void Spawn(GameObject rockType, int spawns) {
        for (int i = 0; i < spawns; i++) Instantiate(rockType, transform);
    }

    IEnumerator wait(float seconds, GameObject rockType, int spawns) {
        yield return new WaitForSeconds(seconds);
        Spawn(rockType, spawns);
    }
}
