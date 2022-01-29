using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Transform target;
    public float lerpSpeed = 0.125f;
    public bool followTarget = true;
    Camera MainCam;
    Vector3 targetPos;
    [SerializeField] CameraBounds cameraBounds;

    float cameraWidth;
    float cameraHeight;

    void Start()
    {
        MainCam = Camera.main;

        cameraHeight = MainCam.orthographicSize;
        cameraWidth = MainCam.aspect * cameraHeight;
    }


    void FixedUpdate()
    {

        if(target == null) { target = PlayerController.playerTransform; }

        if (followTarget == true)
        {

            if(
                target.position.x - cameraWidth < cameraBounds.pos.x - cameraBounds.size.x/2
                ||
                target.position.x + cameraWidth > cameraBounds.pos.x + cameraBounds.size.x/2
                ||
                target.position.y - cameraHeight < cameraBounds.pos.y - cameraBounds.size.y/2
                ||
                target.position.y + cameraHeight > cameraBounds.pos.y + cameraBounds.size.y/2
              )
            {

            }
            else
            {
                targetPos = new Vector3(target.position.x, target.position.y, -10);
            }

            targetPos.z = -10;

            Vector3 lerpPos = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.fixedDeltaTime);
            transform.position = lerpPos;

        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(cameraBounds.pos, cameraBounds.size);
    }

}

[Serializable]
class CameraBounds
{
    public Vector2 pos;
    public Vector2 size;
}