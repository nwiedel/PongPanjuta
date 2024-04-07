using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _GameUIController : MonoBehaviour
{
    public Text player1Text;
    public Text player2Text;
    public Text player1Goas;
    public Text player2Goals;
    public Text actionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateActionText(string s)
    {
        actionText.text = s;
    }
}
