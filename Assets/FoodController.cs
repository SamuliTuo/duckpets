using UnityEngine;

public class FoodController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Duck"))
        {
            collision.GetComponent<DuckController>().Ate();
            Destroy(gameObject);
        }
    }
}
