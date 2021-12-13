// UpwardSkyStudios
using UnityEngine;

public class CircuitboardOscilloscopeScreen : MonoBehaviour
{
    const int NUMBEROFANIMTILESACROSS = 4;
    const int NUMBEROFWAVEOPTIONSVERTICALLY = 4;

    public enum Waveforms
    {
        Analog,
        Digital,
        Low,
        High
    };

    public bool PoweredOn = true;

    public Waveforms DesiredWaveform = Waveforms.Analog;

    [Tooltip("Frames Per Second")] [Range(0.5f, 240f)]
    public int FPS = 15;

    private Vector2 _textureSize;
    private Renderer _renderer;
    private int _indexX = 0;
    private int _indexY = 1;

    private float _activeQuotientTimer = 0;

    // Use this for initialization
    void Start()
    {
        _textureSize = new Vector2(1.0f / NUMBEROFANIMTILESACROSS, 1.0f / NUMBEROFWAVEOPTIONSVERTICALLY);

        _renderer = GetComponent<Renderer>();
        if (_renderer == null)
        {
            Debug.LogWarning("Warning! CircuitboardOscilloscopeScreen script attached to game object " + transform.name +
                             " doesn't have a Renderer component!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_renderer != null)
        {
            if (_activeQuotientTimer >= 1.0f / Mathf.Clamp(FPS, 0.5f, 240f)) //if been long enough, run an update...
            {
                _activeQuotientTimer = 0; //reset timer

                //update visibility
                _renderer.enabled = PoweredOn;

                //update indexes
                ++_indexX;
                if (_indexX > NUMBEROFANIMTILESACROSS)
                {
                    _indexX = 1;
                    switch (DesiredWaveform)
                    {
                        case Waveforms.Analog:
                            _indexY = 3;
                            break;
                        case Waveforms.Digital:
                            _indexY = 4;
                            break;
                        case Waveforms.Low:
                            _indexY = 1;
                            break;
                        case Waveforms.High:
                        default:
                            _indexY = 2;
                            break;
                    }
                }

                //update material offset
                _renderer.material.SetTextureOffset("_MainTex",
                    new Vector2(_indexX * _textureSize.x, -_indexY * _textureSize.y));
            }
            else
            {
                //just increment timer and wait...
                _activeQuotientTimer += Time.deltaTime;
            }
        }
    }
}