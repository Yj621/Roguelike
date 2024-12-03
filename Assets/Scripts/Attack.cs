using UnityEngine;

public class Attack : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && !PlayerController.Instance.isAttack && PlayerController.Instance.isCut)
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                PlayerController.Instance.CutAttack(enemy);
            }
        }

        if (other.gameObject.tag == "Enemy" && !PlayerController.Instance.isAttack && PlayerController.Instance.isSeriesCut)
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy != null)
            {
                PlayerController.Instance.SeriesCutAttack(enemy);
            }
        }
    }
}
