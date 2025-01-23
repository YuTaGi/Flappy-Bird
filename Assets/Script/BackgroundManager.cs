using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject[] backgrounds; // Array เก็บพื้นหลัง
    public int[] scoreThresholds;    // คะแนนที่ใช้เปลี่ยนพื้นหลัง
    private int currentBackgroundIndex = 0;
    private int score = 0;           // เปลี่ยนเป็นวิธีการติดตามคะแนนของคุณ

    void Start()
    {
        // แสดงพื้นหลังแรกเท่านั้น
        ActivateBackground(0);
    }

    void Update()
    {
        // เช็คคะแนนปัจจุบันเพื่อเปลี่ยนพื้นหลัง
        if (currentBackgroundIndex < scoreThresholds.Length &&
            score >= scoreThresholds[currentBackgroundIndex])
        {
            ChangeBackground();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    private void ChangeBackground()
    {
        currentBackgroundIndex++;
        ActivateBackground(currentBackgroundIndex);
    }

    private void ActivateBackground(int index)
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(i == index);
        }
    }
}
