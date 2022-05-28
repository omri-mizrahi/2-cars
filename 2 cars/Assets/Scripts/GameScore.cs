using UnityEngine;

public class GameScore : MonoBehaviour
{
    #region Variables
    public static int CurrentGameScore;
    #endregion

    void Awake()
    {
        CurrentGameScore = 0;
    }
}
