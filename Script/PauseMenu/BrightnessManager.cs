using UnityEngine;
using UnityEngine.SceneManagement;

public class BrightnessManager : MonoBehaviour
{
    private static BrightnessManager instance;

    void Awake()
    {
        // Chỉ tạo 1 bản duy nhất
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Mỗi khi Scene mới load → đặt lại độ sáng đã lưu trong PlayerPrefs
        float savedBrightness = PlayerPrefs.GetFloat("Brightness", 1f);
        RenderSettings.ambientIntensity = savedBrightness;

        Debug.Log($"Scene '{scene.name}' loaded → Brightness = {savedBrightness}");
    }
    /*
     Cách hoạt động
    DontDestroyOnLoad(gameObject) giữ BrightnessManager khi chuyển Scene.
    SceneManager.sceneLoaded tự kích hoạt mỗi lần Scene load xong.          
    Trong OnSceneLoaded, bạn khôi phục độ sáng bằng PlayerPrefs.
     */
}
