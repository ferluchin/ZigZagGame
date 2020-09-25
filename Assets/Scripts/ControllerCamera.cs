using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 posINI;
    // Start is called before the first frame update
    void Start()
    {
        posINI = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position +posINI;
    }
}
