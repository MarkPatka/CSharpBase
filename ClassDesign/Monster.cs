using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDesign
{
    //    3) Разработать полноценный класс Moster(монстр в компьютерной игре жанра РПГ). Минимальный состав:

    //Конструкторы: 2 или более, один из которых - по умолчанию.Должны обеспечивать комфортные варианты создания монстра.

    //Методы:
    //* int GetAttack(int bonus); (получить точное значение силы атаки в диапазоне[MinAttack; MaxAttack] + bonus)
    //* void Wounds(int damage); (вычитает damage из его HP; при этом HP не может уйти в минус!!!)
    //* void Heal(); (полностью исцеляет монстра).

    enum TypesofMonster { ghost, zombie, demon, fantom, vampire, dragon, werewolf, mutant, animal, goblin}
    class Monster
    {
        private string _name;
        private int _hp;
        private int _maxHP;
        private int _minAttack;
        private int _maxAttack;
        private string WarCry { get; set; }
        private string DieCry { get; set; }



        public TypesofMonster MonsterType { get; set; }

        public string TypeofMonsterText
        {
            get
            {
                // про свитч-кейс помню, решил так

                return (MonsterType == TypesofMonster.ghost ? "Призрак" :
                       (MonsterType == TypesofMonster.animal ? "Животное" :
                       (MonsterType == TypesofMonster.demon ? "Демон" :
                       (MonsterType == TypesofMonster.dragon ? "Дракон" :
                       (MonsterType == TypesofMonster.fantom ? "Фантом" :
                       (MonsterType == TypesofMonster.goblin ? "Гоблинн" :
                       (MonsterType == TypesofMonster.mutant ? "Мутант" :
                       (MonsterType == TypesofMonster.vampire ? "Вампир" :
                       (MonsterType == TypesofMonster.werewolf ? "Оборотень" : "Зомби")))))))));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value)) _name =  value;
                else throw new Exception("Вы не ввели имя");
            }
        }

        public int MaxHP
        {
            get { return _maxHP; }
            set
            {
                if (value > 0 && value <= 500) _maxHP = value;
                else throw new Exception("Количество здоровья монстра должно быть в диапазоне от 0 до 500");
            }
        }

        public int HP
        {
            get { return _hp; }
            set
            {
                if (value >= 0 && value <= _maxHP) _hp = value;
                else throw new Exception($"Ошибка, уровень здоровья от 0 до {MaxHP}");
            }
        }

        public bool IsDie
        {
            get
            {
                if (_hp > 0) return false;
                else return true;
            }
        }

        public int MinAttack
        {
            get { return _minAttack; }
            set
            {
                if (value > 1 && value <= 20) _minAttack = value;
                else throw new Exception("Минимальные значения атаки в диапазоне от 1 до 20");
            }
        }

        public int MaxAttack
        {
            get { return _maxAttack; }
            set
            {
                if (value > 20 && value <= 100) _maxAttack = value;
                else throw new Exception("Максимальные значения атаки в диапазоне от 21 до 100");
            }
        }

        public string GetInfo
        {
            get
            {
                return $"Выбран монстр: {TypeofMonsterText}\nИмя: {Name}\nЗдоровье: {HP}\nАтака (мин.): {MinAttack}\n" +
                    $"Атака (макс.): {MaxAttack}";
            }
        }

        public Monster() { } 

        public Monster(string name, TypesofMonster monster, int maxHP, int hp, int minAttack, int maxAttack, string warCry, string dieCry)
        {
            Name = name;
            MonsterType = monster;
            MaxHP = maxHP;
            HP = hp;
            MinAttack = minAttack;
            MaxAttack = maxAttack;
            WarCry = warCry;
            DieCry = dieCry;
        }

        public int GetAttack(int bonus, Monster m1)
        {
            Random rnd = new Random();
            int attack = rnd.Next(m1.MinAttack, m1.MaxAttack + 1) + bonus;
            return attack;
        }

        
        public void Wounds(int damage, Monster m1)
        {
            if (damage < m1.HP) m1.HP -= damage;
            else m1.HP = 0;

            bool isDie = m1.IsDie;
        }

        public void Heal(Monster m1) => m1.HP = m1.MaxHP;

    }
}
