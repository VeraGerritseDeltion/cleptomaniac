using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    public static int here;
    public static Restart restart;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        if (restart == null)
        {
            restart = this;
        }
        else if (restart != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Restarted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
