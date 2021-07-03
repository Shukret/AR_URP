using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparancyFound : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Renderer[] renderer;
    float trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = 0;
        for (int i=0; i<renderer.Length; i++)
        {
            renderer[i].material.color = Color.white * 0;
        }
        StartCoroutine(NotTrans());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
            StartCoroutine(ToTrans());
    }

    IEnumerator NotTrans()
    {
        while (trans < 0.5f)
        {
            yield return new WaitForSeconds(0.04f);
            trans+=0.1f;
            if (trans==0.5f)
            {
                trans=1;
            }
            for (int i=0; i<renderer.Length; i++)
            {
                renderer[i].material.color = Color.white * trans;
            }
        }
    }

    IEnumerator ToTrans()
    {
        trans = 1;
        while (trans > 0.5f)
        {
            yield return new WaitForSeconds(0.01f);
            trans-=0.1f;
            if (trans==0.5f)
            {
                trans=0;
                yield return new WaitForSeconds(0.1f);
                Destroy(prefab);
            }
            for (int i=0; i<renderer.Length; i++)
            {
                renderer[i].material.color = Color.white * trans;
            }
        }
    }
}