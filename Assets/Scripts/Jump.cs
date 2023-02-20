using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour, IJump
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    public float jumpDelay;
    private float jumpTime = 0;

    [SerializeField] private float _force;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    public void Execute()
    {
        if (Time.time < jumpDelay + jumpTime)
        {
            return;
        }
        _animator.SetInteger("isJump", 1);
        jumpTime = Time.time;
        _rigidbody.AddForce(transform.forward * _force);
    }

    public void AnimFalse()
    {
        _animator.SetInteger("isJump", 0);
    }
}

public interface IJump
{
    void Execute();
}