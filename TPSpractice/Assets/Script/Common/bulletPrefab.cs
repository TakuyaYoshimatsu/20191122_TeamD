using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPrefab : MonoBehaviour
{
    public float timer = 3.0f;
    public GameObject explode;//explodeにはunity上でprefabを関連付けます
    public GameObject exploadPos;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.gray;
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "fence")
        //{
        Instantiate(explode, exploadPos.transform.position, Quaternion.identity);
        Destroy(gameObject);
        //}

    }
}
