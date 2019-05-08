using System.Collections;
using UnityEngine;
using EZCameraShake;

public class MainClass : MonoBehaviour
{
    public static float screenHeightUnits;
    public static float screenWidthUnits;

    public static float mapWidthUnits;
    public static float mapHeightUnits;

    public static bool isGameRunning = false;
        
    private Animator animator;

    private void Start()
    {
        isGameRunning = true;
        animator = GetComponent<Animator>();
        ShipControll.OnGameOver += GameOver;
    }

    void Update()
    {
        screenHeightUnits = 2.0f * Camera.main.orthographicSize;
        screenWidthUnits = (Screen.width * screenHeightUnits) / Screen.height;

        mapWidthUnits = screenWidthUnits;
        mapHeightUnits = screenHeightUnits;
    }
    
    public void GameOver()
    {
        isGameRunning = false;
        SoundManager.playSound(SoundManager.Sound.DESTROY);
        CameraShaker.Instance.ShakeOnce(5.0f, 10.0f, .1f, 2.0f);
        animator.SetTrigger("GameOver");
    }
    

}
