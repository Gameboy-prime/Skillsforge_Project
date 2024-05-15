using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialGameEnd : MonoBehaviour
{
    [SerializeField] public GameObject gameOverBox;
    public TutorialEndGame endGame;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered Trigger");
            endGame.GetComponent<TutorialEndGame>().enabled = false;
            gameOverBox.SetActive(true);
            

            Invoke(nameof(HeyEnd), .3f);


        }
    }

    public void HeyEnd()
    {
        Time.timeScale = 0;

    }
}
