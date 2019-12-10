using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one instance of Player found!");
            return;
        }
        instance = this;
    }
    #endregion

    private float score;
    private float money = 40000;
    private bool onMainMenu;

    public SpriteRenderer Head;
    public SpriteRenderer LeftHand;
    public SpriteRenderer RightHand;
    public SpriteRenderer Torso;
    public SpriteRenderer Weapon;

    [SerializeField]
    private TextMeshProUGUI scoreLabel;

    public float Money { get => money; set => money = value; }
    public float Score { get => score; set => score = value; }
    public bool OnMainMenu { get => onMainMenu; set => onMainMenu = value; }

    void Start()
    {

    }
    public void AddMoney(float money)
    {
        this.money += money;
    }
    public void SubMoney(float money)
    {
        this.money -= money;
        if (this.money < 0)
            this.money = 0;
    }
    public float GetMoney()
    {
        return this.money;
    }

}
