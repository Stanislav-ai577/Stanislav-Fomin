using UnityEngine;

public class RefInt : MonoBehaviour
{
    private void Start()
    {
        Health health = new Health();

        DebugA(in health);
        Debug.Log(health);
    }

    private void DebugA(in Health value)
    {
        Debug.Log(value.ToString());
    }

    public class Health
    {
        public float Amount;
    }
}
