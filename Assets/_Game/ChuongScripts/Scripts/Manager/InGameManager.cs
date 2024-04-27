using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace ChuongCustom
{
    public enum StateGame
    {
        Flipping,
        Stop,
        Lose,
        Hold
    }

    public class InGameManager : Singleton<InGameManager>
    {
        [SerializeField] public int PriceToPrice = 1;

        private StateGame _state;

        public StateGame State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;

                    GameAction.OnStateChange?.Invoke(value);

                    if (value == StateGame.Lose)
                    {
                        Manager.ScreenManager.OpenScreen(ScreenType.Lose);
                    }
                }
            }
        }

        private void Start()
        {
            ScoreManager.Reset();

            State = StateGame.Stop;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                switch (State)
                {
                    case StateGame.Flipping:
                        break;
                    case StateGame.Lose:
                        break;
                    case StateGame.Stop:
                        State = StateGame.Hold;
                        break;
                    case StateGame.Hold:
                        break;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                switch (State)
                {
                    case StateGame.Flipping:
                        break;
                    case StateGame.Lose:
                        break;
                    case StateGame.Stop:
                        break;
                    case StateGame.Hold:
                        State = StateGame.Flipping;

                        Knife.Instance.Flip();
                        break;
                }
            }
        }

        [Button]
        public void Win()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Result);
            //todo:
        }

        [Button]
        public void Lose()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Lose);
            //todo:
        }

        [Button]
        public void BeforeLose()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.BeforeLose);
            //todo:
        }

        public void Retry()
        {
            //retry
            //todo:
            SceneManager.LoadScene("GameScene");
        }

        public void Continue()
        {
            //continue

            //todo:
        }
    }
}