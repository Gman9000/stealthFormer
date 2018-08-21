using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;       // REMEMBER TO SET IN INSPECTOR
    public GameObject topRight;
    public GameObject bottomLeft;

    private float minY;
    private float minX;
    private float maxY;
    private float maxX;

    private void Start()
    {
        minY = bottomLeft.transform.position.y;
        minX = bottomLeft.transform.position.x;
        maxY = topRight.transform.position.y;
        maxX = topRight.transform.position.x;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), -10);
    }
}
