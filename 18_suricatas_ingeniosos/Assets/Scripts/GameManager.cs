using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject playerPrefab;
    public Transform[] spawnPoints;
    public int playersCount = 2;
    public List<GameObject> players = new List<GameObject>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        // limpiar anteriores
        foreach(var p in players) if(p) Destroy(p);
        players.Clear();

        for (int i = 0; i < playersCount; i++)
        {
            Transform sp = spawnPoints.Length > i ? spawnPoints[i] : spawnPoints[0];
            GameObject p = Instantiate(playerPrefab, sp.position, Quaternion.identity);
            p.name = "Player" + (i+1);
            PlayerController pc = p.GetComponent<PlayerController>();
            pc.playerId = i + 1;
            // asignar UI sliders, etc
            players.Add(p);
        }

        // spawn hazards (ejemplo: n fogatas alrededor)
        SpawnHazards();
    }

    void SpawnHazards()
    {
        // puedes instanciar prefabs FireHazard en posiciones aleatorias del área
    }

    public void PlayerDied(GameObject player)
    {
        // control de ronda: si sólo queda 1 jugador -> declarar ganador
        int alive = 0;
        GameObject last = null;
        foreach(var p in players)
        {
            if (p != null && p.activeSelf) { alive++; last = p; }
        }

        if (alive <= 1)
        {
            // ganador = last
            Debug.Log("Winner: " + (last ? last.name : "nobody"));
            // mostrar UI y reiniciar ronda tras delay
            Invoke(nameof(StartRound), 3f);
        }
    }
}
