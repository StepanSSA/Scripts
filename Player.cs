using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Button PlayBtn;
    [SerializeField]
    private Button PauseBtn;
    [SerializeField]
    private string VideoUrl;

    // Start is called before the first frame update
    void Start()
    {
        var player = gameObject.GetComponent<VideoPlayer>();
        player.url = VideoUrl;
        player.audioOutputMode = VideoAudioOutputMode.AudioSource;
        player.EnableAudioTrack(0, true);
        player.Prepare();

        PlayBtn?.onClick.AddListener(() => OnClickPlayBtn(player));
        PauseBtn?.onClick.AddListener(() => OnClickPauseBtn(player));
    }

    private void OnClickPlayBtn(VideoPlayer player)
    {
        player.Play();
        Debug.Log("Play btn clecked");
    }

    private void OnClickPauseBtn(VideoPlayer player)
    {
        player.Pause();
        Debug.Log("Pause btn clecked");
    }
}
