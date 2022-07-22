using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace damage_counter
{
    class SwordDamage
    {
        private const int BASE_DAMAGE = 3;
        private const int FLAME_DAMAGE = 2;

        /// <summary>
        /// Содержит в себе посчитанный урон
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Получает и устанавливает полученный ролл
        /// </summary>
        private int roll;
        public int Roll
        {
            get { return roll; }
            set
            {
                roll = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// True, если меч огненный; false в противном случае
        /// </summary>
        private bool flaming;
        public bool Flaming
        {
            get { return flaming; }
            set
            {
                flaming = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// True, если меч магический; false в противном случае
        /// </summary>
        private bool magic;
        public bool Magic
        {
            get { return magic; }
            set
            {
                magic = value;
                CalculateDamage();
            }
        }

        /// <summary>
        /// Вычисляет повреждения в зависимости от текущих значений свойств
        /// </summary>
        public void CalculateDamage()
        {
            decimal magicMultiplier = 1M;
            if (Magic) magicMultiplier = 1.75M;

            Damage = BASE_DAMAGE;
            Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
            if (Flaming) Damage += FLAME_DAMAGE;
        }

        /// <summary>
        /// Конструктор вычисляет повреждения для значений Magic и Flaming по умолчанию и начального броска 3d6
        /// </summary>
        /// <param name="startingRoll"></param>
        public SwordDamage(int startingRoll)
        {
            roll = startingRoll;
            CalculateDamage();
        }
    }
}
