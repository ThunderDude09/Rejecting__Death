using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
 //   public int level;
    public float health;
    public float[] position;
    public int LV;
    public PlayerData (Health player)
    {
        health = player.playerHp;
        LV = player.sceneNum;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
    

}
