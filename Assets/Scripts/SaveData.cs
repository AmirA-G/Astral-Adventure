using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public int health;
    public int collectables;
    public float[] position;
    public int sceneNumber;

    public SaveData (Player player)
    {
        health = player.health;
        collectables = player.collectable;

        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
