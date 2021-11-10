using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーン遷移管理。
/// </summary>
public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private Transform _sceneContainer = default;

    /// <summary>
    /// 現在表示しているシーン。
    /// </summary>
    public Scenes CurrentScene { get; private set; }

    /// <summary>
    /// 管理中の全てのシーンのルート <see cref="GameObject"/> 一覧。
    /// </summary>
    public IEnumerable<GameObject> SceneRoots
    {
        get
        {
            foreach (Transform t in _sceneContainer)
            {
                yield return t.gameObject;
            }
        }
    }

    void Start()
    {
        CurrentScene = Scenes.Home;
    }

    /// <summary>
    /// シーンを変更する。
    /// </summary>
    /// <param name="scene">移行先シーン。</param>
    public void Change(Scenes scene)
    {
        if (CurrentScene == scene) { return; }

        var beforePanel = GetCurrentScenePanel();
        beforePanel.SetActive(false);

        CurrentScene = scene;
        var afterPanel = GetCurrentScenePanel();
        afterPanel.SetActive(true);
    }

    /// <summary>
    /// 現在のシーンのルートゲームオブジェクトを取得する。
    /// </summary>
    /// <returns>現在のシーンのルートゲームオブジェクト。</returns>
    public GameObject GetCurrentScenePanel()
    {
        foreach (var scene in SceneRoots)
        {
            if (scene.name == CurrentScene.ToString())
            {
                return scene;
            }
        }

        return default;
    }
}
