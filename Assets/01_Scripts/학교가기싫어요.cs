using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class 학교가기싫어요 : MonoBehaviour
{
    [SerializeField] GameObject boxObj;
    [SerializeField] SpriteRenderer boxSprite;
    [SerializeField] SpriteRenderer changeSprite;
    [SerializeField] Image storePanel;
    [SerializeField] Image box;
    [SerializeField] TextMeshProUGUI pushF;
    [SerializeField] Vector2 size;
    [SerializeField] LayerMask layer;
    PlayerController pc;
    private  bool isOpenShop = false;
    private bool isOpenBox = false;
    [SerializeField] private bool inHouse = false;

    private void Start()
    {
        boxSprite = GetComponent<SpriteRenderer>();
        changeSprite = GetComponent<SpriteRenderer>();
        pc = GetComponent<PlayerController>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    private void Update()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, size, 0, layer);
        //Debug.Log(hit);
        if(hit != null)
        {
            if (hit.gameObject.tag == "Home")
            {
                Debug.Log("Home");
                pushF.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    pushF.gameObject.SetActive(false);
                    UnityEngine.SceneManagement.SceneManager.LoadScene("InHouse");
                    inHouse = true;
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Debug.Log("종료");
                    }
                }
                else if (inHouse && hit.gameObject.tag == "Door")
                {
                    Debug.Log("Village");
                    UnityEngine.SceneManagement.SceneManager.LoadScene("Village");
                }
            }

            if (hit.gameObject.tag == "Store")
            {
                pushF.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    storePanel.gameObject.SetActive(true);
                    isOpenShop = true;
                    pc.enabled = false;
                }
                if (Input.GetKeyDown(KeyCode.Escape) && isOpenShop)
                {
                    Debug.Log(11);
                    storePanel.gameObject.SetActive(false);
                    isOpenShop = false;
                    pc.enabled = true;
                }
            }

            if (hit.gameObject.tag == "Box")
            {
                Debug.Log("Box");
                pushF.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene("Main");
                }
            }
        }
        else
        {
            pushF.gameObject.SetActive(false);
            storePanel.gameObject.SetActive(false);
            box.gameObject.SetActive(false);
            pc.enabled = true;
        }
    }
}

