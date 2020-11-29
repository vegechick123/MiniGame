using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Direct : MonoBehaviour
{
    public GameObject posPlayer;
    public GameObject negPlayer;
    public GameObject lightSource;
    public float speed;
    public float timeCost;
    private float timeCount = 0;
    private Vector2 direction = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timeCount += Time.deltaTime;
        if (timeCount >= timeCost)
        {
            speed = 0;
        }
        else
        {   
                    
            posPlayer.GetComponent<Rigidbody2D>().velocity = speed*direction;
            negPlayer.GetComponent<Rigidbody2D>().velocity = -speed*direction;
            
        }
        if (timeCount >= timeCost + 0.5)
        {
            lightSource.SetActive(false);
            posPlayer.SetActive(false);
            negPlayer.SetActive(false);
            SceneManager.LoadScene("Level0", LoadSceneMode.Single);
        }
    }
}
