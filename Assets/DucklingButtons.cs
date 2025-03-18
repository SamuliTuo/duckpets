using UnityEngine;

public class DucklingButtons : MonoBehaviour
{
    public GameObject egg;
    public Transform eggSpawnPos;
    [Space(10)]
    public GameObject food;
    public GameObject water;
    public GameObject karate;

    public void GiveFood()
    {
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        var clone = Instantiate(food, spawnPosition, Quaternion.identity);
        clone.gameObject.SetActive(true);
    }

    public void GiveWater()
    {
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        var clone = Instantiate(water, spawnPosition, Quaternion.identity);
        clone.gameObject.SetActive(true);
    }

    public void GiveKarate()
    {
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        var clone = Instantiate(karate, spawnPosition, Quaternion.identity);
        clone.gameObject.SetActive(true);
    }

    public void BuyEgg()
    {
        var clone = Instantiate(egg, eggSpawnPos.position, Quaternion.identity);
        clone.gameObject.SetActive(true);
    }
}
