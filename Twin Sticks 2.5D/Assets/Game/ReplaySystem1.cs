using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem1 : MonoBehaviour {

    private const int BufferFrames = 100;
    private myKeyFrame[] KeyFrames = new myKeyFrame[BufferFrames];

    private Rigidbody rigidBody;

    private GameManager manager;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        manager = GameManager.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        Record();
        if(manager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
	}

    public void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % BufferFrames;
        print("Reading frame " + frame);
        transform.position = KeyFrames[frame].pos;
        transform.rotation = KeyFrames[frame].rotation;
    }

    public void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % BufferFrames;
        float time = Time.time;
        print("Writing Frame " + frame);

        KeyFrames[frame] = new myKeyFrame(time, transform.position, transform.rotation);
    }
}

public struct myKeyFrame
{
    public float frameTime;
    public Vector3 pos;
    public Quaternion rotation;

    public myKeyFrame(float atime, Vector3 aPosition, Quaternion aRotation)
    {
        frameTime = atime;
        pos = aPosition;
        rotation = aRotation;
    }
}

