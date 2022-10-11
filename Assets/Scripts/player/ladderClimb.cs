using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderClimb : MonoBehaviour
{
    player_movement player_Movement;
    public GameObject player;

    bool on_ladder = false;
    float start_time;

    // Start is called before the first frame update
    void Start()
    {
        player_Movement = GetComponent<player_movement>();
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(on_ladder == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                player.transform.position += Vector3.up * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                player.transform.position -= Vector3.up * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                player.transform.position = Vector3.Lerp(player.transform.position, Camera.main.transform.forward - new Vector3(0f, 0f, 3f), ((Time.time - start_time) / 3f) * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ladder")
        {
            player_Movement.enabled = false;
            on_ladder = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "ladder")
        {
            player_Movement.enabled = true;
            on_ladder = false;
        }
    }
}
