using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private double click_count = 0;
    private bool onece = true;

    HomeScene HomeScene_script;
    // Start is called before the first frame update
    void Start()
    {
        HomeScene_script = obj.GetComponent<HomeScene>();
        //HomeScene_script._quantity=click_count;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Tsuruta_Click()
    {

        HomeScene_script._quantity *= 2;

        //if (onece == false)
        //{
        //    ++click_count;
        //}
        //click_count *= 2;
        //onece = false;
    }
}
