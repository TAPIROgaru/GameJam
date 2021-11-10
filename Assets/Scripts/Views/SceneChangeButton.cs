using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// シーン変更ボタン。
/// </summary>
[RequireComponent(typeof(Button))]
public class SceneChangeButton : MonoBehaviour
{
    /// <summary>
    /// シーン マネージャー。
    /// </summary>
    [SerializeField]
    private SceneManager _manager = null;

    /// <summary>
    /// ボタンが押されたときの移動先シーン。
    /// </summary>
    [SerializeField]
    private Scenes _scene = Scenes.Home;

    private void Start()
    {
        var button = GetComponent<Button>();
        var e = new Button.ButtonClickedEvent();
        e.AddListener(() =>
        {
            _manager.Change(_scene);
        });
        button.onClick = e;
    }
}
