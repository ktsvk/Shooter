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

    public bool onMainMenu = false;
    public float score = 0;

    public SpriteRenderer Head;
    public SpriteRenderer LeftHand;
    public SpriteRenderer RightHand;
    public SpriteRenderer Torso;
    public SpriteRenderer Weapon;

    private HealthScript healthScript;
    private PlayerMovement playerMovement;
    private Shooting shooting;

    [SerializeField]
    private TextMeshProUGUI scoreLabel;
    void Start()
    {
        healthScript = GetComponent<HealthScript>();
        playerMovement = GetComponent<PlayerMovement>();
        shooting = GetComponent<Shooting>();

    }
    public void ChangeScore()
    {

    }
}
