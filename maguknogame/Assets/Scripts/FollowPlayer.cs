using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class FollowPlayer : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Use this for initialization
    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (PhotonView.Get(player).IsMine)
            {
                this.target = player.transform;
                break;
            }
        }
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}