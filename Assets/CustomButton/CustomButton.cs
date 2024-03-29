using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(AudioSource))]
/// <summary>
/// カスタムボタンクラス
/// </summary>
public class CustomButton : MonoBehaviour, 
    IPointerClickHandler,
    IPointerDownHandler, 
    IPointerUpHandler, 
    IPointerEnterHandler, 
    IPointerExitHandler
{
    [Header("Sprite & Image")]
    [SerializeField, Tooltip("ポインタがオブジェクトを押下した時に差し替えるスプライト")] 
    Sprite _onPointerDownSprite;

    [SerializeField, Tooltip("ポインタがオブジェクトに乗った時に表示するイメージ")] 
    Image _onPointerEnterImage;

    Image _buttonImage;
    Sprite _mainSprite;

    [Header("Audio")]
    [SerializeField, Tooltip("ポインタがオブジェクトに乗った時に出す音源")] 
    AudioClip _onPointerEnterAudio;

    internal void OnSetEvent(object v)
    {
        throw new NotImplementedException();
    }

    [SerializeField, Tooltip("オブジェクト上でポインタを押下し、同一のオブジェクト上で離した時に出す音源")] 
    AudioClip _onPointerClickAudio;

    AudioSource _audioSource;

    int _addSkillNumber;

    /// <summary>
    /// クリックした時にさせたい処理
    /// </summary>
    public event Action<int> OnClickCallback1;
    public event Action OnSceneLoadCallback2;

    private void Start()
    {
        _buttonImage = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
        _mainSprite = _buttonImage.sprite;

        if(_onPointerEnterImage)
        _onPointerEnterImage.enabled = false;

    }
    /// <summary>
    /// クリック
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData) 
    {
        OnClickCallback1?.Invoke(_addSkillNumber);
        OnSceneLoadCallback2?.Invoke();
        Debug.Log("クリック");

        if (!_onPointerClickAudio) return;

        _audioSource.PlayOneShot(_onPointerClickAudio);
    }
    /// <summary>
    /// タップダウン
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData) 
    {
        if (!_onPointerDownSprite) return;

        _buttonImage.sprite = _onPointerDownSprite;
    }
    /// <summary>
    /// タップアップ
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerUp(PointerEventData eventData) 
    {
        if (!_onPointerDownSprite) return;

        _buttonImage.sprite = _mainSprite;
    }
    public void OnPointerEnter(PointerEventData eventData) 
    {
        if (!_onPointerEnterImage) return;

        _onPointerEnterImage.enabled = true;

        if (!_onPointerEnterAudio) return;

        _audioSource.PlayOneShot(_onPointerEnterAudio);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_onPointerEnterImage) return;

        _onPointerEnterImage.enabled = false;
    }
    public void OnSetEvent(Action<int> e, int index)
    {
        OnClickCallback1 += e;
        _addSkillNumber = index;
    }
    public void OnSetEvent(Action e)
    {
        OnSceneLoadCallback2 += e;
    }
}
