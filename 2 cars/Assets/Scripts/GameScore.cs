using UnityEngine;

public class GameScore : MonoBehaviour
{
    #region Variables
    public static int CurrentGameScore;
    #endregion

    void Awake()
    {
        CurrentGameScore = 0;

        GameObject[] prevScoreObjs = GameObject.FindGameObjectsWithTag(Consts.GameScoreTag);
        if (prevScoreObjs.Length > 1) {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this);
    }
}
