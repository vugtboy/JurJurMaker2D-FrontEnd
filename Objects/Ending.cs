using UnityEngine;
using System.Collections;
public class Ending : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GameObject.Find("#Finish").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Tomato"))
        {
            anim.SetTrigger("Victory");
            transform.parent.gameObject.SetActive(false);
        }
    }
}
