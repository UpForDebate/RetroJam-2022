using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextManaging : MonoBehaviour
{
    Canvas _canvas;
    Animation _animation;
    [SerializeField]
    TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        _animation = _canvas.GetComponent<Animation>();
        
    }
    int i = 0;
    public void ChangeText()
    {
        _canvas.GetComponentInChildren<Image>().color = new Color(0, 0, 0, 0);
        _text.text = "Don't worry, I'm here to save you!";
        _text.color = new Color(255, 255, 255, 0);
    }
    public void TextAppear()
    {
        _animation.Play();
    }
}
