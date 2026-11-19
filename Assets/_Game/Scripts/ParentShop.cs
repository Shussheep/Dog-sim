using UnityEngine;
using TMPro;

public class ParentShop : MonoBehaviour
{
    [SerializeField] int money = 10;
     TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        tmp.text = "You have " + money + "$";
    }

    public bool canBuy(int cost) 
    {
        if (money - cost >= 0)
        {
            money -= cost;
            tmp.text = "You have " + money + "$";
            return true;
        }
        return false;
    }
}
