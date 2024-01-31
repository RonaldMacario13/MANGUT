using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrigadeiroController : MonoBehaviour
{

    public float _moveSpeedBrigadeiro = 3.5f;
    private Vector2 _brigadeiroDirection;
    private Rigidbody2D _brigadeiroRB2D;
    private Animator _brigadeiroAnimator;

    public DetectionController _detectionArea;

    private SpriteRenderer _spritRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _brigadeiroRB2D = GetComponent<Rigidbody2D>();
        _spritRenderer = GetComponent<SpriteRenderer>();
        _brigadeiroAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _brigadeiroDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (_brigadeiroDirection.sqrMagnitude > 0)
        {
            _brigadeiroAnimator.SetBool("isMoving", true);
        } else {
            _brigadeiroAnimator.SetBool("isMoving", false);
        }
    }

    private void FixedUpdate() 
    {
        if (_detectionArea.detectedObjs.Count > 0)
        {
            _brigadeiroDirection = (_detectionArea.detectedObjs[0].transform.position - transform.position).normalized;

            _brigadeiroRB2D.MovePosition(_brigadeiroRB2D.position + _brigadeiroDirection * _moveSpeedBrigadeiro * Time.fixedDeltaTime);

            if (_brigadeiroDirection.x > 0)
            {
                _spritRenderer.flipX = false;
            }
            else if (_brigadeiroDirection.x < 0)
            {
                _spritRenderer.flipX = true;
            }
        }
    }
}
