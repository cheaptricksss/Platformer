using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSmoothFollow : MonoBehaviour
{
    public Transform target;
    // starting target
    // public Transform startFollow;

    public float followSpeed = 0.125f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void LateUpdate()
    {
      
        transform.position = target.position + offset;
        
    }
}
   