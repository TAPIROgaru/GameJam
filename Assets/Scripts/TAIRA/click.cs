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

    // Start is called before the first frame update
    void Start()
    {
        move = (destination.position - start.position) / 5;
    }

    // Update is called once per frame
    void Update()
    {
        Taira_Move();
    }

    void Taira_OnClick()
    {
        _click = true;
        button.transform.position = start.position;
    }
    void Taira_Move()
    {
        if (!_click) { return; }

        Vector3 pos = button.transform.position;
        pos += move;
        button.transform.position = pos;

        if (button.transform.position == destination.position)
        {
            _click = false;
        }
    }
}
