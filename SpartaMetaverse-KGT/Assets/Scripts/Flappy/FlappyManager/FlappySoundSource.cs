using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappySoundSource : MonoBehaviour
{
    private AudioSource audioSource;

    public void Play(AudioClip clip, float soundEffectVolume, float soundEffectPitchVariance)
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();  // 만약 AudioSource 컴포넌트 없으면 가져오기

        CancelInvoke();  // 이전에 예약된 모든 Invoke  호출 취소. 이유는 Invoke가 중복 호출될 수 있어서.
        audioSource.clip = clip;  // AduioSource의 clip을 지정된 clip으로 설정
        audioSource.volume = soundEffectVolume;  // AduioSource의 볼륨을 지정된 볼륨으로 설정
        audioSource.Play();
        audioSource.pitch = 1f + Random.Range(-soundEffectPitchVariance, soundEffectPitchVariance);  // pitch를 지정된 범위 내에서 랜덤하게 설정

        Invoke("Disable", clip.length + 2); // clip 길이 2초 뒤에 Diable 메서드 호출
    }

    public void Disable()
    {
        audioSource.Stop();  // 재생 중지
        Destroy(this.gameObject);
    }

}
