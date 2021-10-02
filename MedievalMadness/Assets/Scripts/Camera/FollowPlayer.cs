using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    void FixedUpdate()
    {
        // Adjust camera position to player position
        this.transform.position = new Vector3(player.position.x, player.position.y, this.transform.position.z);
    }
}
