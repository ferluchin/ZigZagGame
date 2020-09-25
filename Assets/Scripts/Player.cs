using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Text txtScore;
    public Text txtTime;
    private int score;
    private float time;

    public float force;
    private bool changeDir;
    private Vector3 dir;
    private Rigidbody rb;

    public GameObject contentCoins;


    void Start()
    {
        
        changeDir = false;
        rb= GetComponent<Rigidbody>();
        dir = new Vector3 (0,0,0);
        score=0;
        time= 25;

    }

    // Update is called once per frame
    void Update()
    {

        time -= Time.deltaTime;
        if (time <= 0)
        {   
            restartGame();

        }

        txtTime.text = "Tiempo: "+time.ToString("F2");
        if (transform.position.y < -1) {
            restartGame();
        }
        if (Input.GetMouseButtonDown(0) )
        {
            rb.Sleep();
            if (changeDir)
            {
                dir = new Vector3 (0,0,-1);
                changeDir = false;
            } else
            {
                dir = new Vector3(-1,0,0);
                changeDir = true;
            }
        }
    }
    void FixedUpdate(){
        rb.MovePosition(transform.position + dir * Time.deltaTime*force);
    }

    void OnTriggerEnter(Collider obj){
        if (obj.gameObject.tag == "coin")
        {
            obj.gameObject.SetActive(false);
            score++;
            txtScore.text = "Puntaje :"+score.ToString();
        }
        if (obj.gameObject.tag =="win")
        {
            
        }
    }

    void restartGame(){
        this.transform.position = new Vector3(4,1,4);
        rb.Sleep();
        dir = new Vector3(0,0,0);
        score = 0;
        time= 25;

        for (int i = 0; i < contentCoins.transform.childCount; i++)
        {
            contentCoins.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
