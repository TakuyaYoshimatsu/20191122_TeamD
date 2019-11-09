using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panda2 : MonoBehaviour
{

    private CharacterController characterController;
    private Vector3 Velocity;
    public float JumpPower;
    public Transform verRot;
    public Transform horRot;
    public float MoveSpeed;
    private Animator anim;//②Animator型の変数</span>
    public int Panda2_HP;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();//②Animatorを変数に代入
    }

    // Update is called once per frame
    void Update()
    {
        float X_Rotation = Input.GetAxis("Mouse X");
        float Y_Rotation = Input.GetAxis("Mouse Y");
        horRot.transform.Rotate(new Vector3(0, X_Rotation * 2, 0));
        verRot.transform.Rotate(-Y_Rotation * 2, 0, 0);

        if (Input.GetKey(KeyCode.Keypad8))//
        {
            Debug.Log(MoveSpeed);
            Debug.Log(this.gameObject.transform.forward * MoveSpeed * Time.deltaTime);
            characterController.Move(this.gameObject.transform.forward * MoveSpeed * Time.deltaTime);
            anim.SetBool("Run", true);//②アニメーターのRunをtrueにする
        }

        else if (Input.GetKeyUp(KeyCode.Keypad8))//②Wキーがはなされたら 
        {
            anim.SetBool("Run", false);//②アニメーターのRunをfalseにする
        }

        if (Input.GetKey(KeyCode.Keypad5))
        {
            characterController.Move(this.gameObject.transform.forward * -1f * MoveSpeed * Time.deltaTime);
            anim.SetBool("Run", true);//②アニメーターのRunをtrueにする
        }

        else if (Input.GetKeyUp(KeyCode.Keypad5))//②Sキーがはなされたら 
        {
            anim.SetBool("Run", false);//②アニメーターのRunをfalseにする
        }

        if (Input.GetKey(KeyCode.Keypad4))
        {
            characterController.Move(this.gameObject.transform.right * -1 * MoveSpeed * Time.deltaTime);
            anim.SetBool("Run", true);//②アニメーターのRunをtrueにする
        }

        else if (Input.GetKeyUp(KeyCode.Keypad4))//②Aキーがはなされたら 
        {
            anim.SetBool("Run", false);//②アニメーターのRunをfalseにする
        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            characterController.Move(this.gameObject.transform.right * MoveSpeed * Time.deltaTime);
            anim.SetBool("Run", true);//②アニメーターのRunをtrueにする
        }

        else if (Input.GetKeyUp(KeyCode.Keypad6))//②Dキーがはなされたら 
        {
            anim.SetBool("Run", false);//②アニメーターのRunをfalseにする
        }

        characterController.Move(Velocity);
        Velocity.y += Physics.gravity.y * Time.deltaTime;

        if (characterController.isGrounded)
        {
            Debug.Log("setti");
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                Velocity.y = JumpPower;
            }
        }
        if (Panda2_HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Debug.Log("当たった");
            Panda2_HP -= 1;
        }

    }
}