using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject playerPrefab;       // Prefab del jugador
    public Transform[] spawnPoints;       // Lugares donde aparecerán los jugadores
    public int playersCount = 1;          // Cantidad de jugadores
    public List<GameObject> players = new List<GameObject>();

    void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else 
            Destroy(gameObject);
    }

    void Start()
    {
        StartRound();
    }

    public void StartRound()
    {
        // eliminar jugadores anteriores
        foreach (var p in players)
        {
            Destroy(p);
        }
        players.Clear();

        // instanciar jugadores según playersCount
        for (int i = 0; i < playersCount; i++)
        {
            // Verifica que haya suficientes puntos de spawn
            if (i >= spawnPoints.Length)
            {
                Debug.LogError("No hay suficientes spawnPoints asignados en el GameManager");
                return;
            }

            Transform sp = spawnPoints[i];
            GameObject p = Instantiate(playerPrefab, sp.position, Quaternion.identity);

            // asignar id único para input
            var controller = p.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.playerId = i + 1;
            }

            players.Add(p);
        }

        SpawnHazards();
    }

    void SpawnHazards()
    {
        // Aquí van los hazards si luego los agregas
    }

    public void PlayerDied(GameObject player)
    {
        players.Remove(player);

        if (players.Count == 1)
        {
            Debug.Log("GANADOR: " + players[0].name);
        }
    }
}
