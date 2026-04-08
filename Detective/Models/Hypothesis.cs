namespace Detective.Models
{
    /// <summary>
    /// Приоритет версии
    /// </summary>
    public class Priority
    {
        /// <summary>
        /// Уровень приоритета (основная, запасная, маловероятная)
        /// </summary>
        public string Level { get; set; }
    }

    /// <summary>
    /// Создатель версии
    /// </summary>
    public class Creator
    {
        /// <summary>
        /// Имя создателя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Роль создателя (детектив, полицейский, эксперт)
        /// </summary>
        public string Role { get; set; }
    }

    /// <summary>
    /// Информация о подтверждении версии
    /// </summary>
    public class Confirmation
    {
        /// <summary>
        /// Подтверждена ли версия
        /// </summary>
        public bool IsConfirmed { get; set; }

        /// <summary>
        /// Дата последнего обновления
        /// </summary>
        public string LastUpdate { get; set; }
    }

    /// <summary>
    /// Модель версии расследования
    /// </summary>
    public class Hypothesis
    {
        /// <summary>
        /// Уникальный идентификатор версии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор дела
        /// </summary>
        public int CaseId { get; set; }

        /// <summary>
        /// Описание версии
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Приоритет версии
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Создатель версии
        /// </summary>
        public Creator Creator { get; set; }

        /// <summary>
        /// Статус подтверждения
        /// </summary>
        public Confirmation Confirmation { get; set; }
    }
}