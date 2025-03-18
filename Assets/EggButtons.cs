using UnityEngine;

public class EggButtons : MonoBehaviour
{
    public GameObject egg;
    public GameObject duckling;
    public GameObject ducklingButtons;
    public int eggHeatLimit = 20;

    private int eggHeat = 0;

    public void GiveHeat()
    {
        eggHeat++;
        if (eggHeat >= eggHeatLimit)
        {
            HatchEgg();
        }
    }

    void HatchEgg()
    {
        Vector3 pos = egg.transform.position;
        Destroy(egg);
        var clone = Instantiate(duckling, pos + Vector3.up * 0.5f, Quaternion.identity);
        clone.gameObject.SetActive(true);

        ducklingButtons.SetActive(true);
        gameObject.SetActive(false);
    }
}
