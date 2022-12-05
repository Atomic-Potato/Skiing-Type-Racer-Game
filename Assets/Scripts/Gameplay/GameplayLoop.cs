using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayLoop : MonoBehaviour
{
    [SerializeField] int distanceToWin  = 1000;

    [Space]
    [SerializeField] Transform startTransform;
    [SerializeField] Transform playerTransform;
    
    [Space]
    [SerializeField] string sceneName;
    
    [Space]
    [SerializeField] UserInterfaceManager uiManager;


    [HideInInspector] public float timer = 20f;
    [HideInInspector] public int currentDistance = 0;

    void Update(){
        currentDistance = (int)Mathf.Abs(startTransform.position.x - playerTransform.position.x);

        if(timer > 0){
            timer -= Time.deltaTime;
            if(timer < 0)
                timer = 0;
        }

        if(currentDistance > distanceToWin && timer > 0){
            uiManager.DisplayWinScreen();
        }
        else if(timer <= 0) {
            uiManager.DisplayLooseScreen();
        }   
    }

    public void RestartGame(){
        SceneManager.LoadScene(sceneName);
    }
}