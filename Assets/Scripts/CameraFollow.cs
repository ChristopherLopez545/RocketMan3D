using System.Diagnostics;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    private void Awake()
    {
        player = FindFirstObjectByType<PlayerController>().transform;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetpos = player.position + offset;
        targetpos.x = 0;
        transform.position = targetpos;
    }
}
