using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sculptable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ApplySongOfSculpting(int level)
    {
        Debug.Log("Sculptable: This probably needs to be overwritten");
    }
}
