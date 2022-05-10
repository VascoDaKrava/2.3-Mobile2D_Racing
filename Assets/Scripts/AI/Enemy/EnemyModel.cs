﻿namespace AI
{
    public sealed class EnemyModel : IEnemyModel
    {

        #region Fields

        private readonly int _minMoney = 5;

        private float _power;

        #endregion


        #region IEnemyModel

        public float GetPower => _power;


        // money (<_min) + health / force
        public void CalculatePower(IPlayerData data)
        {
            float money = data.GetData(PlayerDataType.Money);
            float health = data.GetData(PlayerDataType.Health);
            float force = data.GetData(PlayerDataType.Force);

            _power = (money < _minMoney) ? money : _minMoney;

            if (health != 0.0f &&
                force != 0.0f)
            {
                _power += health / force;
            }
        }

        #endregion

    }

    public interface IEnemyModel
    {
        float GetPower { get; }
        void CalculatePower(IPlayerData data);
    }
}