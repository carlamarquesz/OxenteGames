using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{
    public HealthBar healthBar;
    HealthSystem healthSystem;

    void Start(){
      healthSystem = new HealthSystem(10);
      healthBar.Setup(healthSystem);
    }

    public void VamoDarDano(){
      healthSystem.Damage(1);
      Debug.Log("porcentage "+healthSystem.GetHealthPercent());
      Debug.Log("vida "+healthSystem.GetHealth());
    }
}
