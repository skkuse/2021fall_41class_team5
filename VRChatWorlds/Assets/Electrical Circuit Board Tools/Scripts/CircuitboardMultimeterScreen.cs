// UpwardSkyStudios
using UnityEngine;

public class CircuitboardMultimeterScreen : MonoBehaviour
{
    [Header("Display Values")] public bool NegativeValue = true;
    public string DisplayDigits = "1237";
    
    [Range(0,3)]
    public int DecimalPositions = 2;

    [Header("Setup Objects")] public Renderer Digit0;
    public Renderer Digit1;
    public Renderer Digit2;
    public Renderer Digit3;

    public Renderer Decimal0;
    public Renderer Decimal1;
    public Renderer Decimal2;

    public Renderer SignNegative;

    private GameObject _signNegativeObj;
    private GameObject[] _decimalObjects;

    private bool _renderersFound = false;
    private string _digitsLast = "    ";
    private bool _negValueLast = false;
    private int _decimalPosLast = 0;

    private Vector2 _textureSize;


    // Use this for initialization
    void Start()
    {
        if (Digit0 != null && Digit1 != null && Digit2 != null && Digit3 != null
            && Decimal0 != null && Decimal1 != null && Decimal2 != null
            && SignNegative != null)
        {
            _renderersFound = true;
            _signNegativeObj = SignNegative.transform.gameObject;
            _decimalObjects = new GameObject[3]
            {
                Decimal0.gameObject,
                Decimal1.gameObject,
                Decimal2.gameObject
            };

            //setup uvw coords
            _textureSize = new Vector2(1.0f / 4, 1.0f / 4);
            //_renderer.material.SetTextureScale("_MainTex", _textureSize);


            Update();
        }
        else
        {
            Debug.LogWarning("Warning! CircuitboardMultimeterScreen script attached to game object " + transform.name +
                             " doesn't have one or more of it's public screen display digits assigned in the Inspector!");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        DecimalPositions = Mathf.Clamp(DecimalPositions, 0, 3);

        if (_renderersFound
            && (DisplayDigits != _digitsLast || NegativeValue != _negValueLast || DecimalPositions != _decimalPosLast))
        {
            _digitsLast = DisplayDigits;
            _negValueLast = NegativeValue;
            _decimalPosLast = DecimalPositions;
            
            UpdateScreen();
        }
    }

    void UpdateScreen()
    {
        _signNegativeObj.SetActive(NegativeValue);

        _decimalObjects[0].SetActive(DecimalPositions == 1);
        _decimalObjects[1].SetActive(DecimalPositions == 2);
        _decimalObjects[2].SetActive(DecimalPositions == 3);

        if (DisplayDigits.Length < 4)
        {
            DisplayDigits = string.Concat(DisplayDigits, "    ");
            //buffer string so indexes accessed below never out of range
        }

        UpdateDigit(Digit0, DisplayDigits[3]);
        UpdateDigit(Digit1, DisplayDigits[2]);
        UpdateDigit(Digit2, DisplayDigits[1]);
        UpdateDigit(Digit3, DisplayDigits[0]);
    }

    void UpdateDigit(Renderer r, char digit)
    {
        float x = 0;
        float y = 0;

        bool blankOut = false;

        switch (digit)
        {
            case '0':
                x = 0;
                y = 0;
                break;
            case '1':
                x = 1;
                y = 0;
                break;
            case '2':
                x = 2;
                y = 0;
                break;
            case '3':
                x = 3;
                y = 0;
                break;
            case '4':
                x = 0;
                y = 1;
                break;
            case '5':
                x = 1;
                y = 1;
                break;
            case '6':
                x = 2;
                y = 1;
                break;
            case '7':
                x = 3;
                y = 1;
                break;
            case '8':
                x = 0;
                y = 2;
                break;
            case '9':
                x = 1;
                y = 2;
                break;
            case 'a':
            case 'A':
                x = 2;
                y = 2;
                break;
            case 'b':
            case 'B':
                x = 3;
                y = 2;
                break;
            case 'c':
            case 'C':
                x = 0;
                y = 3;
                break;
            case 'd':
            case 'D':
                x = 1;
                y = 3;
                break;
            case 'e':
            case 'E':
                x = 2;
                y = 3;
                break;
            case 'f':
            case 'F':
                x = 3;
                y = 3;
                break;
            default: //includes blank or off
                blankOut = true;
                break;
        }

        //update uvw position for the digit
        r.material.SetTextureOffset("_MainTex", new Vector2(x * _textureSize.x, -y * _textureSize.y));
        r.enabled = !blankOut;
    }

}
