using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
 

    public LightShadowForm player;
    public AudioClip brokenDoors;
    public AudioClip turnOnOffMachine;
    public AudioClip createBridge;
    private bool isEnter;
    private bool isBroken;
    private bool isCreate;
    private bool isChange;
    private AudioSource music;
    // Start is called before the first frame update
    void Awake()
    {
        music = gameObject.AddComponent<AudioSource>();
        music.playOnAwake = false;
        isEnter = false;
        isBroken = false;
        isCreate = false;

    }

   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "machine")
            isEnter = true;
        if (collision.tag == "door" && player.state == Form.Shadow)
            isBroken = true;
        if (collision.tag == "bridge" && player.state == Form.Light)
            isCreate = true;
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "machine")
            isEnter = false;
        if (collision.tag == "door" && player.state == Form.Shadow)
            isBroken = false;
        if (collision.tag == "bridge" && player.state == Form.Light)
            isCreate = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v") && isEnter)
        {
            music.clip = turnOnOffMachine;
            music.Play();
           
        }
        if (Input.GetKeyDown("v") && isBroken)
        {
            music.clip = brokenDoors;
            music.Play();
            isBroken = false;
        }
        if (Input.GetKeyDown("v") && isCreate)
        {
            music.clip = createBridge;
            music.Play();
            isCreate = false;
        }
    }
}
