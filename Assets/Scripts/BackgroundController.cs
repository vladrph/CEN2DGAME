using UnityEngine;


/**
 * Specific Purpose: The purpose of this class is to control the parallax background in level 2.
 * It defines the speed of the furthest parallax effect relative to the nearest.
 * 
 */

public class BackgroundController : MonoBehaviour
{
     Transform _cam; 
     private Vector3 _camStartPos;
     private float _distance;
     

    private GameObject[] _backgrounds;
    private Material[] _mat;
    private float[] _backSpeed;

    private float _farthestBack;

    [Range(0.01f, 0.05f)] 
    public float parallaxSpeed;
    
    void Start()
    {
        _cam = Camera.main.transform;
        _camStartPos = _cam.position;

        int backCount = transform.childCount;
        _mat = new Material[backCount];
        _backSpeed = new float[backCount];
        _backgrounds = new GameObject[backCount];




        for (int i = 0; i < backCount; i++)
        {
            _backgrounds[i] = transform.GetChild(i).gameObject;
            _mat[i] = _backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);

    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) 
        {

            if ((_backgrounds[i].transform.position.z - _cam.position.z) > _farthestBack)
            {
                _farthestBack = _backgrounds[i].transform.position.z - _cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            _backSpeed[i] = 1 - (_backgrounds[i].transform.position.z - _cam.position.z) / _farthestBack;
        }


    }


    private void LateUpdate()
    {
        _distance = _cam.position.x - _camStartPos.x;
        transform.position = new Vector3(_cam.position.x, transform.position.y, 0);


        for (int i = 0; i < _backgrounds.Length; i++)
        {
            float speed = _backSpeed[i] * parallaxSpeed;
            _mat[i].SetTextureOffset("_MainTex", new Vector2(_distance,0)* speed);
        }
    }

}
