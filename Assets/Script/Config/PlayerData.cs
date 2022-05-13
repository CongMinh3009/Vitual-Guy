using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ConfigData/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float _maxSpeed;
    public float _jumpHeight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
