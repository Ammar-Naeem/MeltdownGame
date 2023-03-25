using System.Collections;
using System.Collections.Generic;
using Meltdown;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform[] enemySpawnPoints;
    
    List<Character> _characters = new List<Character>();
    // Start is called before the first frame update
    void Start()
    {
        InstantiateAllCharacters();
    }

    private void InstantiateAllCharacters()
    {
        InstantiatePlayer();
        InstantiateEnemies();
    }

    private void InstantiatePlayer()
    {
        Character character = Instantiate(playerPrefab, playerSpawnPoint).GetComponent<Player>();
        AddToCharacterList(character);
    }

    private void InstantiateEnemies()
    {
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            Character character = Instantiate(playerPrefab, enemySpawnPoints[i])
                .GetComponent<Player>();
            AddToCharacterList(character);
        }
    }

    private void AddToCharacterList(Character character)
    {
        
    }

    
}
