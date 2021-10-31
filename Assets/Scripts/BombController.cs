using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    private void Start()
    {
        StartCoroutine(DetonationCoroutine());
    }

    IEnumerator DetonationCoroutine()
    {
        yield return new WaitForSeconds(5f);
        if (enemies.Capacity != 0)
            foreach (var enemy in enemies)
                enemy.GetComponent<Enemy>().Damaged();
        else Debug.Log("Suka");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            enemies.Add(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            if(enemies.IndexOf(collision.gameObject) < enemies.Capacity)
                enemies.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
                enemies.Remove(collision.gameObject);
    }
}
