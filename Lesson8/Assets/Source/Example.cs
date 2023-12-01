using UnityEngine;

public class Example : MonoBehaviour
{
    private void Start()
    {
        Health health = new Health();
        Health healthBoy = new Health();

        health.Amount = 10;
        healthBoy.Amount = 20;

        Debug.Log("Health" + health.Amount);
        Debug.Log("HealthBoy " + healthBoy.Amount);

        healthBoy = health;

        Debug.Log("HealthBoy " + healthBoy.Amount);

        health.Amount = 20;

        Debug.Log("HealthBoy " + healthBoy.Amount);


    }
}

public class Health
{
    public float Amount;
}
