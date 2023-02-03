using UnityEngine;
public class BulletController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Vector3 movement;

    public void Fire(Vector3 direction)
    {
        movement = direction * speed;

    }
    private void FixedUpdate()
    {

        transform.position += movement * Time.deltaTime;
    }
}