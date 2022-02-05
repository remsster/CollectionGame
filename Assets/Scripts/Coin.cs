using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinCount = 0;
    public float rate = 100;
    // Start is called before the first frame update
    void Start()
    {
        ++CoinCount;
    }

    void OnDestroy()
    {
        --Coin.CoinCount;
        if (Coin.CoinCount <= 0)
        {
            GameObject Timer = GameObject.Find("LevelTimer");
            Destroy(Timer);
            GameObject[] FireworkSystems = GameObject.FindGameObjectsWithTag("Fireworks");
            if (FireworkSystems.Length <= 0) { return; }
            foreach (GameObject obj in FireworkSystems)
            {
                obj.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) { Destroy(gameObject); }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rate * Time.deltaTime);
    }
}
