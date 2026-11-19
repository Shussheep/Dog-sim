using UnityEngine;

public class ShopObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody rb;
    private bool isBoght = false;
    [SerializeField]private ParentShop shop;
    [SerializeField] private int cost = 1;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LockBody(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LockBody(bool should) 
    {
        if (should)
            rb.constraints = RigidbodyConstraints.FreezeAll;
        else
            rb.constraints = RigidbodyConstraints.None;
    }

     void Purches() 
    {
        LockBody(false);
        GameObject next = Instantiate(this.gameObject, transform.position, transform.rotation, null);
        Rigidbody nextRb = next.GetComponent<Rigidbody>();
        nextRb.isKinematic = false;
        nextRb.useGravity = true;

        isBoght = true;
    }

    public void Purches(bool forceBuy)
    {
        if(!isBoght)
        if (forceBuy || shop.canBuy(cost))
        {
            Purches();
        }
        else 
        {
        
        }
    }
}
