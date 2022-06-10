using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    #region Variables
    public string tagToDestroy;
    #endregion

    void Awake()
    {
        GameObject[] existingObjs = GameObject.FindGameObjectsWithTag(tagToDestroy);
        if (existingObjs.Length > 1) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
}
