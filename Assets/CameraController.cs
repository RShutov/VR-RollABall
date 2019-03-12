using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Target;
    public float Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        var position = gameObject.transform.position;
        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y + Offset, position.z);
    }
}
