using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public playerControl pc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("mainPlayer").GetComponent<playerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pc.lastCheckpointPos = transform.position;
        }
    }
}
