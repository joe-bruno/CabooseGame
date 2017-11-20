using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    private GameObject arrow;
    private Transform target = null;
    float timer;

    float timeBetweenArrows = 1f;
    private bool arrowShot;
    

    void Start()
    {
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        rb = arrow.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            target = null;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (target == null)
            return;
        if(timer >= timeBetweenArrows)
        {
            rb.transform.LookAt(target);
            LaunchArrow();
        }
        
       /* float distance = Vector3.Distance(transform.position, target.position);
        bool tooClose = distance < minRange;
        if (!tooClose)
            LaunchArrow();
        */
        
    }

    private void LaunchArrow()
    {
        timer = 0f;
        GameObject arrowInstance = Instantiate(arrow, rb.position, rb.rotation);
        arrowInstance.GetComponent<Rigidbody>().AddForce(arrowInstance.transform.forward * thrust);
        arrowInstance.GetComponentInChildren<MeshRenderer>().enabled = true;
        Destroy(arrowInstance, 3f);
    }
}