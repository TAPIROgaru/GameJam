using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makehair : MonoBehaviour
{

    public GameObject hair;

    //public Vector3 root;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void makehairrandam()
    {
      
            var pos = Vector3.zero;

            pos.x += Random.Range(-35.0f, 35.0f);
            pos.y += Random.Range(-25.0f, 25.0f);

            var obj = Instantiate(hair, transform);
            obj.transform.localPosition = pos;
        
    }
}
