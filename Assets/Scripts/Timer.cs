using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float MaxTime = 60.0f;
    [SerializeField] private float CountDown = 0;
    void Start()
    {
        CountDown = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce time
        CountDown -= Time.deltaTime;
        // Restart level if time runs out
        if (CountDown <= 0)
        {
            Coin.CoinCount = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        
    }
}
