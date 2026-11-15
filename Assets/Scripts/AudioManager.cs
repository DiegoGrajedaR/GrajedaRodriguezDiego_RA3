using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip coinSound;

    [System.Serializable]
    public class SceneMusic 
    {
        public string sceneName;
        public AudioClip musicClip;
    }

    public SceneMusic[] sceneMusicList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip newClip = GetMusicForScene(scene.name);

        if (newClip != null)
        {
            PlayMusic(newClip);
        }
        else 
        {
            audioSource.Stop();
            audioSource.clip = null;
            return;
        }
    }

    private AudioClip GetMusicForScene(string sceneName)
    {
        foreach (var item in sceneMusicList)
        {
            if (item.sceneName == sceneName)
            {
                return item.musicClip;
            }
        }
        return null;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip && audioSource.isPlaying) return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }
}
