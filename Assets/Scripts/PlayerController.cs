using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;

    private int count;
    

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.text = "";
    }


void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);  //memory leak??
        rb.AddForce(movement* speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

System.String EvaluateGameAbility()
    {
        float timeElapsed = Time.realtimeSinceStartup;
        System.String abilityTitle;
        float master = 10;
        float expert = 20;
        float newbie = 30;
        if (timeElapsed < master) abilityTitle = "滚蛋大师";
        else if (timeElapsed < expert) abilityTitle = "滚蛋专家";
        else if (timeElapsed < newbie) abilityTitle = "滚蛋菜鸟";
        else abilityTitle = "建议少侠改玩五子棋";
        return abilityTitle;
    }
void SetCountText()
    {
        countText.text = "奖金： " + count.ToString() + " 万元";
        if (count >= 12)
        {
            //winText.text = "耶，你赢了 "+count.ToString()+" 万人民币！";
            winText.text = System.String.Format("你赢了 {0} 万元人民币！\n 游戏能力：{1}", count.ToString(), EvaluateGameAbility());
        }
    }
}

