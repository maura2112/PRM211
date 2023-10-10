using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get => instance; }

    [Header("UI Score")]
    [SerializeField] protected float currentScore;
    [SerializeField] protected Text scoreText;


    private void Awake()
    {
        if (ScoreManager.instance != null)
        {
            Debug.LogError("Only 1 ScoreManager allow to exist!");
        }
        ScoreManager.instance = this;
    }

    private void Start()
    {
        this.GetScore();
    }

    private void Reset()
    {
        this.LoadComponents();
    }

    private void Update()
    {
        this.SetScore();
    }

    protected virtual void LoadComponents()
    {
        this.scoreText = GameObject.Find("CurrentScoreText").GetComponent<Text>();
    }

    protected virtual void GetScore()
    {
        //this.currentScore = PlayerPrefs.GetFloat("Score");
        this.currentScore = 0;
        PlayerPrefs.SetFloat("Score", this.currentScore);
    }

    protected virtual void SetScore()
    {
        PlayerPrefs.SetFloat("Score", this.currentScore);
        scoreText.text = "" + this.currentScore;
    }
    public virtual void AddScore(float amount)
    {
        this.currentScore += amount;
    }
    public virtual void RemoveScore(float amount)
    {
        this.currentScore -= amount;
    }
}

