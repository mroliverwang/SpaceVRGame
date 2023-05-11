using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBall : MonoBehaviour
{
    public int hit = 0;

    public LayerMask enemy;

    private Collider[] Colliders = new Collider[2];

    [SerializeField]
    private float temp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hit == 1)
        {


            //StartCoroutine("autoAim");

            aim();



        }
    }

    private IEnumerator autoAim()
    {

        

        int n = Physics.OverlapSphereNonAlloc(transform.position, 1f, Colliders, enemy);
        if(hit == 0)
        {
            yield return null;
        }
        if (n > 0)
        {

            
            GetComponent<Rigidbody>().velocity = (Colliders[0].gameObject.transform.position - transform.position) * 150f * Time.deltaTime;
        }
        

        yield return null;
    }


    private void aim()
    {
        int n = Physics.OverlapSphereNonAlloc(transform.position, 0.8f, Colliders, enemy);
        if (hit == 0)
        {
            return;
        }
        if (n > 0)
        {


            GetComponent<Rigidbody>().velocity = (Colliders[0].gameObject.transform.position - transform.position) * 150f * Time.deltaTime;
            hit = 0;
        }
    }
}
