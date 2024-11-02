using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Movment_Paths
{
    public List<Transform> paths;
}

public class Enemy_Sponer : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    public float initialRaidCounts = 4;
    public float initialEnemyCount = 5;
    public float initialTimeBetweenRaids = 3;

    private float currentRaidCount;
    private float currentEnemyCount;
    private float currentTimeBetweenRaids;

    public List<GameObject> spawnedEnemies;

    private int currentWave = 0;

 
    public List<Movment_Paths> Moving_paths;

    public GameObject Ferst_Canvas;
    public GameObject Win_Loss_Canvas;

    public GameObject WinPanel;


    void Start()
    {
        currentRaidCount = initialRaidCounts;
        currentEnemyCount = initialEnemyCount;
        currentTimeBetweenRaids = initialTimeBetweenRaids;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (currentRaidCount > 0)
        {
            yield return new WaitForSeconds(currentTimeBetweenRaids);

            int spawnPointIndex = UnityEngine.Random.Range(0, spawnPoints.Length);

            for (int i = 0; i < currentEnemyCount; i++)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoints[spawnPointIndex].position, Quaternion.identity);
                enemy.GetComponent<EnemyMovment>().Enemy_Sponer = this;
                enemy.GetComponent<EnemyMovment>().moveSpeed = UnityEngine.Random.Range(0.1f, 0.8f);
                enemy.GetComponent<EnemyMovment>().Target_Pos = Moving_paths[UnityEngine.Random.Range(0, Moving_paths.Count)].paths;
                enemy.GetComponent<EnemyMovment>().Move = true;
           
                spawnedEnemies.Add(enemy);

                yield return new WaitForSecondsRealtime(0.8f);
            }

            while (spawnedEnemies.Exists(enemy => enemy != null))
            {
                yield return null;
            }

            currentWave++;
            currentEnemyCount++;
            currentTimeBetweenRaids++;
            currentRaidCount--;

            if (currentRaidCount <= 0 && !spawnedEnemies.Exists(enemy => enemy != null))
            {
                HandleWinCondition(); // فراخوانی تابع پیروزی زمانی که شرایط پیروزی برقرار است
            }
        }
    }

    void Update()
    {
        if (currentRaidCount <= 0 && !spawnedEnemies.Exists(enemy => enemy != null))
        {
            HandleWinCondition(); // بررسی شرایط پیروزی در هر فریم
        }
    }

    // تابع برای پیروزی در بازی
    private void HandleWinCondition()
    {
        Time.timeScale = 0;
        Ferst_Canvas.SetActive(false);
        Win_Loss_Canvas.SetActive(true);
        WinPanel.SetActive(true);
     



    }
}
