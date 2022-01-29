using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Transform target;
    public float lerpSpeed = 0.125f;
    public bool followTarget = true;

    void FixedUpdate()
    {

        if(target == null) { target = PlayerController.playerTransform; }

        if (followTarget == true)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);
            Vector3 lerpPos = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.fixedDeltaTime);
            transform.position = lerpPos;

        }
    }

}
