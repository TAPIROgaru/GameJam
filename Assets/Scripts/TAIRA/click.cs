using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click : MonoBehaviour
{

    [SerializeField]
    private Button button = default;

    [SerializeField]
    private Transform destination;
    [SerializeField]
    private Transform start;

    public bool _click = false;

    private Vector3 move;

    private const int value = 20;

    private int _count = 0;

    // Start is called before the first frame update
    void Start()
    {
        //button.onClick.AddListener(Taira_OnClick);
        move = (destination.position - start.position) / value;
    }

    // Update is called once per frame
    void Update()
    {
        Taira_Move();
    }

    public void Taira_OnClick()
    {
        _click = true;
        button.transform.position = start.position;
    }
    void Taira_Move()
    {
        if (!_click) { return; }

        var rt = (RectTransform)button.transform;
        rt.position += move;
        button.transform.position = rt.position;

        

        if (_count == value)
        {
            _click = false;

            var rt_ = (RectTransform)button.transform;
            rt_.position = start.position;
            button.transform.position = rt.position;

            _count = 0;
        }
        _count++;
    }
}
