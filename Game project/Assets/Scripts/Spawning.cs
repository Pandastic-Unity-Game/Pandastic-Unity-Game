using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawning : MonoBehaviour
{

    private GameObject Decision;

    private GameObject[] SpawnPoints;
    private Transform SpawnPosition;

    public GameObject[] Players;
    public GameObject[] Enemies;
    private GameObject player;

    private RaceDontDestroy DecisionScript;

    // Use this for initialization
    void Start()
    {
        Decision = GameObject.FindGameObjectWithTag("Datas");
        DecisionScript = Decision.GetComponent<RaceDontDestroy>();
        SpawnPoints = GameObject.FindGameObjectsWithTag("Spawn").OrderBy(go => go.name).ToArray();
        SpawnPosition = SpawnPoints[0].transform;

        Instantiate(Players[DecisionScript.selectedPlayer], SpawnPosition);


        for (int i = 0; i < DecisionScript.opponents; i++)
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Length)], SpawnPoints[i + 1].transform);
        }
    }
}