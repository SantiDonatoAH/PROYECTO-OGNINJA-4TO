using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endAttack : MonoBehaviour
{
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator endAttack1()
    {
        yield return new WaitForSeconds(0.1f);
        anim.SetBool("IsPunching", false);
    }
}
