//This is the script called CameraFollow derived from the video "How to Make Camera Follow in Unity 2D"

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform _player;

    private Vector3 _tempPos;


    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    void LateUpdate()
    {
        _tempPos = transform.position;
        _tempPos.x = _player.position.x;
        transform.position = _tempPos;
        Debug.Log("Camera is moving with the player");
    }
}
