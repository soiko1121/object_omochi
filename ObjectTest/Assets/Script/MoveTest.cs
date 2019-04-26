using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTest : MonoBehaviour
{
    int Count;
    Rigidbody rb;

    Vector3 Move;

    public float Speed = 3;
    public float MaxSpeed=3f;
    public bool Inertia = true;

    public Text Txt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //移動のモードを変える
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Count < 3) Count++;
            if (Count == 3) Count = 0;
        }
   
        //キー入力
        Move.x = Input.GetAxis("Horizontal") * Speed;
        Move.y = Input.GetAxis("Vertical") * Speed;

        if (Inertia)
        {
            //キーが押されていない場合は力をなくす
            if (!Input.anyKey) rb.velocity = Vector3.zero;
        }

        //移動
        switch (Count)
        {
            case 0:
                rb.AddForce(MaxSpeed * (Move - rb.velocity));
                break;

            case 1:
                transform.Translate(Move * Time.deltaTime);
                break;

            case 2:
                rb.velocity = Move;
                break;

            default: break;
        }

        //テキスト表示
        switch (Count)
        {
            case 0: Txt.text = "rb.AddForce"; break;
            case 1: Txt.text = "transform.Translate"; break;
            case 2: Txt.text = "rb.velocity"; break;
            default: break;
        }

    }
}
