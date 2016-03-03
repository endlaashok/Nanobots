using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int numberOfEnemies;
    public string[] EnemyType = new string[] { "goodBacteria", "badBacteria", "virus" , "rbc" , "wbc", "nanobot" };
    // Use this for initialization
    void Start () {

        CreateEnemies();

	}

    void CreateEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        { int enemytype= Random.Range(0,4);
            Character newEnemy = new Character(EnemyType[enemytype]);


        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
