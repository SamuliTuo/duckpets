using UnityEngine;

public class EggController : MonoBehaviour
{
    public GameObject duckling;
    public int eggHeatLimit = 20;

    private float eggHeat = 0;


    private void Update()
    {
        if (eggHeat < eggHeatLimit)
        {
            eggHeat += Time.deltaTime;
            if (eggHeat >= eggHeatLimit)
            {
                HatchEgg();
            }
        }
    }

    void HatchEgg()
    {
        Vector3 pos = transform.position;
        var clone = Instantiate(duckling, pos + Vector3.up * 0.5f, Quaternion.identity);
        clone.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
