using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{

    [SerializeField] private float _vitesse = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _vitesse);
        if (transform.position.x > 9f)
        {
            Destroy(gameObject);
        }
    }
}
