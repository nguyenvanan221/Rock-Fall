using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //ship
    public GameObject shipPrefab;
    public Transform shipStartPosition;
    public GameObject CurrentShip { get; private set; }

    //space station
    public GameObject spaceStationPrefab;
    public Transform spaceStationStartPosition;
    public GameObject CurrentSpaceStation { get; private set; }

    public SmoothFollow smoothFollow;
    public CameraFollow cameraFollow;

    public Timer timer;

    //boundary
    public Boundary boundary;

    //UI
    public GameObject inGameUI;
    public GameObject pauseUI;
    public GameObject gameOverUI;
    public GameObject mainMenuUI;
    public GameObject warningUI;

    //check current playing
    public bool gameIsPlaying { get; private set; }

    public AsteroidSpawner asteroidSpawner;

    public bool paused;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowUI(GameObject newUI)
    {
        GameObject[] allUI = {inGameUI, pauseUI, gameOverUI, mainMenuUI};

        foreach (GameObject uI in allUI)
        {
            uI.SetActive(false);
        }

        newUI.SetActive(true);
    }

    public void ShowMainMenu()
    {
        ShowUI(mainMenuUI);

        gameIsPlaying = false;
        asteroidSpawner.spawnAsteroids = false;
    }

    public void StartGame()
    {
        //RewardedAd.Instance.LoadAd();

        ShowUI(inGameUI);

        gameIsPlaying = true;

        if (CurrentShip != null)
        {
            Destroy(CurrentShip);
        }

        if (CurrentSpaceStation != null)
        {
            Destroy(CurrentSpaceStation);
        }

        CurrentShip = Instantiate(shipPrefab);
        CurrentShip.transform.position = shipStartPosition.transform.position;
        CurrentShip.transform.rotation = shipStartPosition.transform.rotation;

        CurrentSpaceStation = Instantiate(spaceStationPrefab);
        CurrentSpaceStation.transform.position = spaceStationStartPosition.transform.position;

        //camera
        smoothFollow.target = CurrentShip.transform;
        cameraFollow.target = CurrentShip.transform;


        asteroidSpawner.spawnAsteroids = true;
        asteroidSpawner.target = CurrentSpaceStation.transform;

        //timer.StartClock();

    }

    public void GameOver()
    {
        ShowUI(gameOverUI);

        gameIsPlaying = false;

        if (CurrentShip != null)
        {
            Destroy(CurrentShip);
        }

        if (CurrentSpaceStation != null)
        {
            Destroy(CurrentSpaceStation);
        }

        warningUI.SetActive(false);
        
        asteroidSpawner.spawnAsteroids = false;

        asteroidSpawner.DestrotyAllAsteroids();

    }

    public void SetPaused(bool paused)
    {
        inGameUI.SetActive(!paused);
        pauseUI.SetActive(paused);

        if (paused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void Update()
    {
        if (CurrentShip == null) { return; }

        float distance = (CurrentShip.transform.position - boundary.transform.position).magnitude;

        // outside Destroy radius
        if (distance > boundary.destroyRadius)
        {
            GameOver();
        }
        //outside Warning radius
        else if (distance > boundary.warningRadius)
        {
            warningUI.SetActive(true);
        }
        else 
        { 
            warningUI.SetActive(false); 
        }
    }
}
