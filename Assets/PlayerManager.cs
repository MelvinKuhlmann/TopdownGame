using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject blueSquare;

    public override void OnStartServer()
    {
        base.OnStartServer();
        Debug.Log("Server started!");
    }

    // Start is called before the first frame update
    void Start()
    {
        createBlueSquare();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createBlueSquare()
    {
        Vector2 spawnPoint = new Vector2(Random.Range(0, 5), Random.Range(0, 5));
        GameObject obj = Instantiate(blueSquare, spawnPoint, Quaternion.identity);
    }
}
