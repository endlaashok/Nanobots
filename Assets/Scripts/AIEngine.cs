using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIEngine : MonoBehaviour {

    //public bool goodBacteria;
    //public bool badBacteria;
    //public bool Virus;
    //public bool rbc;
    //public bool wbc;

    public bool EnemygoodBacteria;
    public bool EnemybadBacteria;
    public bool EnemyVirus;
    public bool Enemyrbc;
    public bool Enemywbc;
    public bool EnemyNanobot;

    public float movespeed = 10.0f;
    public float rotationspeed = 10.0f;

    Character Enemy = new Character("");
    Character CurrentCharacter = new Character("");

    // Use this for initialization

    //to keep track of the distance for random movements
    private float lastXposition;
    private float lastZposition;
    void Start () {
        //GameObject closest = FindClosestNPC();
        //Debug.Log(closest.name);


    }



    // Update is called once per frame
    void Update () {

        
       
        InteraxtWithNPC();

        #region commentedcode
        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //GameObject closest = FindClosestNPC();
        //Debug.Log(closest.name);

        // transform.Translate(Vector3.forward * speed * Time.deltaTime);
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, step);



        //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(closest.transform.position - transform.position), rotationspeed * Time.deltaTime);
        ////move towards the player
        //transform.position += transform.forward * Time.deltaTime * movespeed;

        #endregion

    }

    void FixedUpdate()
    {

    }


    void InteraxtWithNPC()
    {

        List<GameObject> enemy = new List<GameObject>();
        List<Character> enemies = new List<Character>();
        //enemy. = UnityEngine.Object.FindObjectsOfType<GameObject>();

        if (EnemygoodBacteria)
        {
            enemy.Add(GameObject.Find("goodBacteria"));
        }
        if (EnemybadBacteria)
        {
            enemy.Add(GameObject.Find("badBacteria"));
        }
            if (EnemyVirus)
        {
            enemy.Add(GameObject.Find("virus"));
        }
            if (Enemyrbc)
        {
            enemy.Add(GameObject.Find("rbc"));
        }
            if (Enemywbc)
        {
            enemy.Add(GameObject.Find("wbc"));
        }
                if (EnemyNanobot)
        {
            enemy.Add(GameObject.Find("nanobot"));
        }

        GameObject closest = FindClosestNPC(enemies);
        //Debug.Log(closest.name);


        int TresholdHealth = 50;

        if (Enemy.Health > TresholdHealth)
        {
            if (CurrentCharacter.Health > TresholdHealth)
            {
                Chase(closest);
            }
            else if (CurrentCharacter.Health < TresholdHealth)
            {
                Run(Enemy);
            }
        }

       else if (Enemy.Health < TresholdHealth)
        {
            if (CurrentCharacter.Health > Enemy.Health)
            {
                Chase(closest);
            }
            else if (CurrentCharacter.Health < Enemy.Health)
            {
                Run(Enemy);
            }
        }

        Chase(closest);
    }

    void Run(Character enemy)
    {

    }

    void Chase(GameObject closest)
    {
        //Vector3 targetDirection = closest.transform.position - transform.position;
        //transform.position += targetDirection * movespeed * Time.deltaTime;

        float step = movespeed * Time.deltaTime;
        float distance = Vector3.Distance(closest.transform.position, transform.position);

        if (distance > 8)
        {
            transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, step);
        }
    }

    void Run(GameObject closest)
    {
        //Vector3 targetDirection = closest.transform.position - transform.position;
        //transform.position += targetDirection * movespeed * Time.deltaTime;

        float step = movespeed * Time.deltaTime; 
        float distance = Vector3.Distance(closest.transform.position, transform.position);

        if (distance > 8)
        {
            transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, step);
        }
    }

    bool NotInSameGameObject(Character currentObj, Character referenceObj)
    {
        if (currentObj != referenceObj)
        {
            return true;

        }
        else return false;
    }

    GameObject FindClosestNPC(List<Character> enemyList)
    {
        Character[] gos;
         gos = UnityEngine.Object.FindObjectsOfType<Character>();

        // gos = GameObject.FindGameObjectsWithTag("Enemy");
        Character closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (Character go in gos)
        {
            if (enemyList.Contains(go))
            {
                float diff = Vector3.Distance(go.transform.position, transform.position);
                float curDistance = diff;
                if (curDistance < distance && curDistance != 0 && NotInSameGameObject(go, CurrentCharacter))
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            else continue;

        }
       // Debug.Log(distance);
        return closest.transform.root.gameObject;
    }


}
