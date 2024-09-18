using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endAttack2 : MonoBehaviour
{        
    [SerializeField] Animator anim2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator endAttack()
    {
        yield return new WaitForSeconds(0.1f);
        anim2.SetBool("IsPunching", false);
    }
}
