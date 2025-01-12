using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio audioinstance;
    void Awake ()
    {
        if(audioinstance !=null)
        {
        DontDestroyOnLoad(transform.gameObject);
        }else
        {

            DontDestroyOnLoad(transform.gameObject);
            audioinstance = this;
        }
    }
        
    }
