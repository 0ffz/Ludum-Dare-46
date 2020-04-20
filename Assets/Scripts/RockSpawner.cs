using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Timeline;

[Serializable]public class RockSpawn {
    public enum Rocks {
        Normal,
        Light, 
        Heavy,
        LowGrav,
        ReverseGrav,
        Bouncey
    }

    public Rocks spawnObject;
    public int spawns;
    public float delay;
}

public class RockSpawner : MonoBehaviour {
    public static int TotalSpawns;
    
    void Start() {
        GameState.Instance.OnPlanComplete += StartPlaying;
    }

    void StartPlaying() {
        TotalSpawns = GameState.CurrentRound.RockSpawns.Sum(spawn => spawn.spawns);
        foreach(RockSpawn rock in GameState.CurrentRound.RockSpawns)
            StartCoroutine(Wait(rock.delay, GameState.Instance.rocks[(int) rock.spawnObject], rock.spawns));
    }

    void Spawn(GameObject rockType, int spawns) {
        for (int i = 0; i < spawns; i++) Instantiate(rockType, transform);
    }

    IEnumerator Wait(float seconds, GameObject rockType, int spawns) {
        yield return new WaitForSeconds(seconds);
        Spawn(rockType, spawns);
    }
}
