using System;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Great Job");
        if (other.gameObject.tag == "Player")
        {
            ASCIILevelLoader.instance.CurrentLevel++;
        }
    }
}
