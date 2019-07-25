using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioClip soundExplosion;// audioclip 이라는 데이터형 변수 생성
    AudioSource myAudio;// 컴포넌트에서 오디오 가져오기
    public static soundManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (soundManager.instance == null)
        {
            soundManager.instance = this;
        }
    }

    // Update is called once per frame
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundExplosion);
    }
    private void Update()
    {
        
    }
}
