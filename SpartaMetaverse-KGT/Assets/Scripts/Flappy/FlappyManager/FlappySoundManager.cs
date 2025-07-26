using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappySoundManager : MonoBehaviour
{
    public static FlappySoundManager instance;

    [SerializeField][Range(0f, 1f)] private float backgroundVolume;
    [SerializeField][Range(0f, 1f)] private float soundEffectVolume;  // 사운드 효과 볼륨
    [SerializeField][Range(0f, 1f)] private float soundEffectPitchVariance;  // 사운드 효과 피치 변동 범위

    private AudioSource backgroundSource;  // 인스펙터에서 할당할 수 있는 오디오 소스
    public AudioClip backgroundClip;  // 인스펙터에서 할당할 수 있는 배경 음악 클릭

    public FlappySoundSource flappySoundSourcePrefabs;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        backgroundSource = GetComponent<AudioSource>();
        backgroundSource.volume = backgroundVolume;  // 인스펙터에서 설정한 볼륨 적용.
        backgroundSource.loop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        ChangeBackGroundMusic(backgroundClip);  // 배경 음악이 지정되어 있다면 재생.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBackGroundMusic(AudioClip clip)
    {
        if (clip != null)
        {
            backgroundSource.Stop();
            backgroundSource.clip = clip;
            backgroundSource.Play();  // 현재 재생중인 배경 음악이 있다면 중지하고 새로 지정한 배경 음악을 재생.
        }
    }


    public void PlayClip(AudioClip clip)
    {
        if (clip != null)
        {
            FlappySoundSource obj = Instantiate(instance.flappySoundSourcePrefabs);
            FlappySoundSource soundSource = obj.GetComponent<FlappySoundSource>();  // 생성된 프리팹의 FlappySoundSource 컴포넌트 가져오기
            soundSource.Play(clip, instance.soundEffectVolume, instance.soundEffectPitchVariance);
        }
    }

}
