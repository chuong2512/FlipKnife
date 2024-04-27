using System;
using UnityEngine;

namespace ChuongCustom
{
    public class Knife : Singleton<Knife>
    {
        public SpriteRenderer _skin;

        public void Flip()
        {
            rb.freezeRotation = false;
            Debug.Log($"Flipp with power : {PowerSlicer.Instance.Power}");

            AddForce(PowerSlicer.Instance.Power);
        }

        public void AddPoint()
        {
            ScoreManager.Score++;
            Stop();
        }

        public void SetLose()
        {
            Manager.InGame.State = StateGame.Lose;
        }

        public void Stop()
        {
            rb.freezeRotation = true;
            Manager.InGame.State = StateGame.Stop;
        }

        public float torque = 4;
        public float xForce = 10;
        private Rigidbody2D rb;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            _skin.sprite = SkinDataManager.Instance.CurrentSkin;
        }

        void AddForce(float force)
        {
            rb.AddTorque(torque);
            rb.AddForce(Vector2.up * force * xForce);
        }

        public void Check()
        {
            var rot = transform.rotation.eulerAngles.z;

            var check = rot % 360;
            
            Debug.Log($"Check rot : {check}");
            
            if (check > 160 && check < 200)
            {
                AddPoint();
            }
            else
            {
                SetLose();
            }
        }
    }
}