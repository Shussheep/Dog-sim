using UnityEngine;
using System.Collections;

public class Pet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string state = "wander";
    Rigidbody rb;
    public float rotationSpeed = 0.3f;
    float timecount = 0;
    Quaternion direction;
    GameObject target;
    void Start()
    {
        //   Vector3 direction = new Vector3(0, Random.Range(0, 360), 0);
        direction = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "wander")
        {
            if (timecount > 2)
            {
                direction = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
                timecount = 0;
            }



            rb.MoveRotation(Quaternion.Lerp(transform.rotation, direction, timecount));
            timecount += rotationSpeed * Time.deltaTime;
        }
        if (state == "chase")
        {
            direction = Quaternion.Euler(transform.position - target.transform.position);

            rb.MoveRotation(Quaternion.Lerp(transform.rotation, direction, timecount));
            timecount += rotationSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
    }

    public void HanddleVission(Collider other)
    {
        if (other.tag == "toy")
        {
            state = "wander";
            target = other.gameObject;
            timecount = 0;
            Debug.Log("found a toy of " + other.gameObject.name);
        }
    }
}
