using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public bool dashEnabled = true; // Initial state set to true

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
