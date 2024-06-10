using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarrafaPoderosa : MonoBehaviour
{

    [SerializeField]
    private Animator crackbottle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CrackB()
    {
        crackbottle.SetBool("CrackBot", true);
    }
}
