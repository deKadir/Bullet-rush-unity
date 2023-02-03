
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidBody;
    [Range(200, 2000)][SerializeField] private float moveSpeed;

    protected void Move(Vector3 direction)
    {
        myRigidBody.velocity = direction * moveSpeed * Time.deltaTime;
    }


}




