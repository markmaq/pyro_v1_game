using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Proceed to Level 2");

            StartCoroutine(GoToLevel2());
        }
    }

    IEnumerator GoToLevel2()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("SecondLevel");
    }
}
