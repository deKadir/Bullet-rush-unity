
using UnityEngine;

public class FollowController : MonoBehaviour
{
    [SerializeField] Transform target;
    private Vector3 offset;
    private void Awake()
    {
        offset = transform.position + target.position;

    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}