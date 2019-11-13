using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_health : MonoBehaviour
{
    public GameObject boss;
    private Image bar;
    public int total;
    public int current;
    //private int w = 500;
    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        total = boss.GetComponent<hit_to_death>().hits_initial;
        current = total;

    }

    // Update is called once per frame
    void Update()
    {
        current = boss.GetComponent<hit_to_death>().hits_current;
        bar.rectTransform.sizeDelta = new Vector2((500 * current / total), 10);
    }
}
