using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BlockController : MonoBehaviour
{
    [SerializeField] int _blockHp = 1;
    [SerializeField] Text _hpText;

    [SerializeField] AudioSource _audioSource;
    int _saveHp;

    SpriteRenderer _spriteRenderer;
    

    ScoreManager _scoreManager;
    TimeManager _timeManager;
    

    private void Start()
    {
        if (_hpText == null)
        {
            _hpText = GetComponent<Text>();
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GameObject.Find("BlockSE").GetComponent<AudioSource>();
        _scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        _timeManager = GameObject.Find("Timer").GetComponent<TimeManager>();

        OnSetHp();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            Debug.Log($"オブジェクト{name}をクリック");
        }
    }

    public void OnSetHp()
    {
        _blockHp = Random.Range(1, _timeManager._timer);
        _saveHp = _blockHp;
        _hpText.text = _blockHp.ToString();

        ChangeColor(_blockHp);

        this.gameObject.SetActive(true);
    }

    void ChangeColor(int hp)
    {
        if (_blockHp < 15) { _spriteRenderer.color = Color.white; }
        else if (_blockHp < 30) { _spriteRenderer.color = Color.green; }
        else if (_blockHp < 45) { _spriteRenderer.color = Color.cyan; }
        else if (_blockHp < 60) { _spriteRenderer.color = Color.blue; }
        else if (_blockHp < 75) { _spriteRenderer.color = Color.yellow; }
        else if (_blockHp < 90) { _spriteRenderer.color = Color.red; }
        else if (_blockHp > 100) { _spriteRenderer.color = Color.black; }
    }

    public void OnDamageBlock()
    {
        _blockHp -= GameManager._power;
        _hpText.text = _blockHp.ToString();

        if (_blockHp <= 0)
        {
            _scoreManager.ScoreGet(_saveHp);
            _audioSource.Play();
            this.gameObject.SetActive(false);
        }
    }
}
