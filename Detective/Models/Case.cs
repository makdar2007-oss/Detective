using System.Collections.Generic;

namespace Detective.Models
{
    /// <summary>
    /// Информация о статусе дела
    /// </summary>
    public class StatusInfo
    {
        /// <summary>
        /// Текущий статус дела (в работе, закрыто, приостановлено и т.д.)
        /// </summary>
        public string CurrentStatus { get; set; }
    }

    /// <summary>
    /// Детали преступления
    /// </summary>
    public class CrimeDetails
    {
        /// <summary>
        /// Тип преступления (убийство, кража, мошенничество и т.д.)
        /// </summary>
        public string CrimeType { get; set; }

        /// <summary>
        /// Дата открытия дела
        /// </summary>
        public string DateOpened { get; set; }

        /// <summary>
        /// Место совершения преступления
        /// </summary>
        public string CrimeLocation { get; set; }

        /// <summary>
        /// Ведущий детектив по делу
        /// </summary>
        public string LeadDetective { get; set; }
    }

    /// <summary>
    /// Ключевой момент в расследовании
    /// </summary>
    public class KeyMoment
    {
        /// <summary>
        /// Время события
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// Описание события
        /// </summary>
        public string description { get; set; }
    }

    /// <summary>
    /// Хронология событий по делу
    /// </summary>
    public class Timeline
    {
        /// <summary>
        /// Дата и время начала расследования
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Список ключевых моментов расследования
        /// </summary>
        public List<KeyMoment> KeyMoments { get; set; }
    }

    /// <summary>
    /// Модель дела
    /// </summary>
    public class Case
    {
        /// <summary>
        /// Уникальный идентификатор дела
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название дела
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Информация о статусе дела
        /// </summary>
        public StatusInfo Status { get; set; }

        /// <summary>
        /// Детали преступления
        /// </summary>
        public CrimeDetails CrimeDetails { get; set; }

        /// <summary>
        /// Хронология событий
        /// </summary>
        public Timeline Timeline { get; set; }
    }
}