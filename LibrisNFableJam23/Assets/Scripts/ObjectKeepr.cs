using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKeepr : MonoBehaviour
{
    public static ObjectKeepr instance;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
