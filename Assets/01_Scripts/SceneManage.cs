using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class SceneManage : MonoBehaviour
{
    [SerializeField] GameObject boxObj;
    [SerializeField] SpriteRenderer boxSprite;
    [SerializeField] SpriteRenderer changeSprite;
    [SerializeField] Image storePanel;
    [SerializeField] Image box;
    [SerializeField] TextMeshProUGUI pushF;
    [SerializeField] Vector2 size;
    [SerializeField] LayerMask layer;
    [SerializeField] Image fadePanel;
    PlayerController pc;
    private bool isOpenShop = false;
    private bool isOpenBox = false;
    Sequence sequence;
    [SerializeField] private bool inHouse = false;

    private void Start()
    {
        boxSprite = GetComponent<SpriteRenderer>();
        changeSprite = GetComponent<SpriteRenderer>();
        pc = GetComponent<PlayerController>();
        //JsonManager.instance.Load();
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
        if (hit != null)
        {
            if (hit.gameObject.tag == "Home")
            {
                Debug.Log("Home");
                pushF.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    JsonManager.instance.statisticTxt.gameObject.SetActive(false);
                    JsonManager.instance.Save();
                    pushF.gameObject.SetActive(false);
                    sequence = DOTween.Sequence();
                    fadePanel.DOFade(1, 1);
                    sequence.OnComplete(() => SceneManager.LoadScene("InHouse"));
                    inHouse = true;
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Application.Quit();
                    }
                }
            }
            if (inHouse && hit.gameObject.tag == "Door")
            {
                //Debug.Log("Village");
                JsonManager.instance.statisticTxt.gameObject.SetActive(false);
                SceneManager.LoadScene("Village");
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
                boxSprite.sprite = changeSprite.sprite;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    JsonManager.instance.Save();
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
    private void OnDisable()
    {
        sequence.Kill();
    }
}

