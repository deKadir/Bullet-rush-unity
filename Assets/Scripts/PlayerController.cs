using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class PlayerController : MyCharacterController
{
    [SerializeField] private ScreenTouchController input;
    [SerializeField] private ShootController shoot;
    private List<Transform> enemies = new List<Transform>();
    private bool isShooting;
    private int enemyCount;

    private void Start()
    {

        enemyCount = FindObjectsOfType<EnemyController>().Length;
    }
    private void FixedUpdate()
    {
        var direction = new Vector3(input.Direction.x, 0, input.Direction.y);
        Move(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag($"Enemy"))
        {
            Dead();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag($"FinishPoint"))
        {
            Win();
        }
    }
    private void Dead()
    {
        Debug.Log("Dead");
        Time.timeScale = 0;
    }
    private void AutoShoot()
    {
        IEnumerator Do()
        {
            while (enemies.Count > 0)
            {

                var enemy = enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;
                transform.LookAt(enemy.transform);
                shoot.Shoot(direction, transform.position);
                enemies.RemoveAt(0);
                yield return new WaitForSeconds(shoot.Delay);
            }
            isShooting = false;
        }
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(Do());

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag($"Enemy"))
        {
            if (!enemies.Contains(other.transform))
            {

                enemies.Add(other.transform);
            }
            AutoShoot();

        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.transform.CompareTag($"Enemy"))
        {
            enemies.Remove(collider.transform);
        }
    }
    private void Win()
    {
        Debug.Log("Win!");
        var currentEnemyCount = FindObjectsOfType<EnemyController>().Length;
        var result = currentEnemyCount / (float)enemyCount;
        var success = Mathf.Lerp(100, 0, result);
        Debug.Log($"Completed %{success}");
        Time.timeScale = 0;

    }
}

