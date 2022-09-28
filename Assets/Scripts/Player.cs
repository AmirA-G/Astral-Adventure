using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;
    public int collectable = 0;

    public void SavePlayer()
    {
        SerializationManager.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        SaveData data = SerializationManager.LoadPlayer();

        health = data.health;
        collectable = data.collectables;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
