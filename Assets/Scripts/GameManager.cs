using System.Collections;
using System.Collections.Generic;
using Meltdown;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References:")] [SerializeField]
    private RideController rideController;
    
    [Header("Data:")]
    [SerializeField] private Transform characterParent;
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
        Character character = Instantiate(playerPrefab, playerSpawnPoint.transform.position + 
                                                        new Vector3(0, 0.1f, 0), Quaternion.identity , 
            characterParent).GetComponent<Player>();
        AddToCharacterList(character);
    }

    private void InstantiateEnemies()
    {
        for (int i = 0; i < enemySpawnPoints.Length; i++)
        {
            Character character = Instantiate(enemyPrefab, enemySpawnPoints[i].transform.position + 
                                                           new Vector3(0, 0.1f, 0), Quaternion.LookRotation(enemySpawnPoints[i]
                                                           .forward), 
                characterParent).GetComponent<Enemy>();

            character.RideCylinderReference = rideController.GetRideCylinderReference();
            AddToCharacterList(character);
        }
    }

    private void AddToCharacterList(Character character)
    {
        
    }

    
}
