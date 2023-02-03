using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private BulletController bulletPrefab;
    [SerializeField] public float Delay;


    public void Shoot(Vector3 direction, Vector3 position)
    {
        var bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bullet.Fire(direction);
    }
}