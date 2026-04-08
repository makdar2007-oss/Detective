namespace Detective.Models
{
    /// <summary>
    /// Ссылка на подозреваемого
    /// </summary>
    public class PersonRef
    {
        /// <summary>
        /// Идентификатор подозреваемого
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Имя подозреваемого
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Детали мотива
    /// </summary>
    public class MotiveDetails
    {
        /// <summary>
        /// Тип мотива (месть, наследство, ревность, корысть)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Сила мотива (от 1 до 10)
        /// </summary>
        public int Strength { get; set; }

        /// <summary>
        /// Описание мотива
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// Модель мотива преступления
    /// </summary>
    public class Motive
    {
        /// <summary>
        /// Уникальный идентификатор мотива
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Подозреваемый
        /// </summary>
        public PersonRef Person { get; set; }

        /// <summary>
        /// Детали мотива
        /// </summary>
        public MotiveDetails MotiveDetails { get; set; }
    }
}