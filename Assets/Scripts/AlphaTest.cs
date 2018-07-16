using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaTest : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _sprite;
    [SerializeField]
    private Image _target;
    [SerializeField]
    private Transform _pin;

    private Color[] _data;



    private int Width
    {
        get
        {
            return _sprite.sprite.texture.width;
        }
    }
    private int Height
    {
        get
        {
            return _sprite.sprite.texture.height;
        }
    }
    // Use this for initialization
    void Start()
    {
        _data = _sprite.sprite.texture.GetPixels();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (TestAlpha(pos))
            {
                _pin.transform.localPosition = new Vector3(pos.x, pos.y, _pin.transform.localPosition.z);
            }
        }
    }

    private bool TestAlpha(Vector3 pos)
    {
        pos -= transform.position;
        int x = (int)(pos.x * 100) + Width / 2;
        int y = (int)(pos.y * 100) + Height / 2;

        if (x > 0 && x < Width && y > 0 && y < Height)
        {
            var color = _data[y * Width + x];
            _target.color = color;
            if (color.a > 0.00001f)
            {
                return true;
            }
        }

        return false;
    }
}
