using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour

{ 
    
    public void AddDamage() {

        gameObject.SetActive(false);
        GameController.Score += 10;
      
    }
  
}
