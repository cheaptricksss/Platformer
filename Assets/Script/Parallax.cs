using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float startPos;
    public GameObject cam;
    [SerializeField] private float parallax;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (cam.transform.position.x * parallax);
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
