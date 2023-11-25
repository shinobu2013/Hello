using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moppy : MonoBehaviour
{
    enum MoppyStatus
    {
        Sleeping,
        Waked,
        Catched,
        Escaped,
    };
    [SerializeField] GameObject retryButton;
    public Sprite sleepImage, wakedImage, catchedImage;
    MoppyStatus status = MoppyStatus.Sleeping;
    Vector3 initialPosition;
    float xSpeed = 0.0f;
    float ySpeed = 0.0f;

    void Start()
    {
        Transform tf = GetComponent<Transform>();
        initialPosition = tf.position;
        Init();
    }

    void Init()
    {
        retryButton.SetActive(false);
        Transform tf = GetComponent<Transform>();
        tf.position = initialPosition;
        Image image = GetComponent<Image>();
        image.sprite = sleepImage;
        status = MoppyStatus.Sleeping;
        xSpeed = 0.0f;
        ySpeed = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (status == MoppyStatus.Waked)
        {
            Transform tf = GetComponent<Transform>();
            tf.position += new Vector3(xSpeed, ySpeed, 0f);
            if ((tf.position.x <= -1000f || 1000f <= tf.position.x) || (tf.position.y <= -1000f || 1000f <= tf.position.y))
            {
                status = MoppyStatus.Escaped;
                retryButton.SetActive(true);
            }
        }
    }

    public void onTapped()
    {
        if (status == MoppyStatus.Sleeping)
        {
            status = MoppyStatus.Waked;
            Image image = GetComponent<Image>();
            image.sprite = wakedImage;
            xSpeed = Random.Range(-3.0f, 3.0f);
            ySpeed = Random.Range(-3.0f, 0.0f);
        }
        else if (status == MoppyStatus.Waked)
        {
            status = MoppyStatus.Catched;
            Image image = GetComponent<Image>();
            image.sprite = catchedImage;
            retryButton.SetActive(true);
        }
    }

    public void Restart()
    {
        Init();
    }
}
