using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;

    private void Start()
    {
        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }
        if (SceneTransition.instance == null)
        {
            Instantiate(canvas);
        }
    }
}
