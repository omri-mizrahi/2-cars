using UnityEngine;

public class GameMode : MonoBehaviour
{
    #region Variables
    public static string CurrentGameMode;
    #endregion

    void Awake()
    {
        GameObject[] prevScoreObjs = GameObject.FindGameObjectsWithTag(Consts.Tags.GameMode);
        if (prevScoreObjs.Length > 1) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
}
