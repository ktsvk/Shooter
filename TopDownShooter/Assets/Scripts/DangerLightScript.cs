using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerLightScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private void Start()
    {
        speed = Random.Range(3f, 13f);
    }
    void Update()
    {
        var rotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + speed);
        transform.Rotate(rotation);
    }
}
