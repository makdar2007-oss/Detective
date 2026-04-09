using System;
using System.Collections.Generic;

namespace Detective.Models
{
    /// <summary>
    /// Участник встречи
    /// </summary>
    public class MeetingPerson
    {
        /// <summary>
        /// Идентификатор участника
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Имя участника
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// Детали встречи
    /// </summary>
    public class MeetingDetails
    {
        /// <summary>
        /// Время встречи
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// Место встречи
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Была ли встреча тайной
        /// </summary>
        public bool IsSecret { get; set; }
    }

    /// <summary>
    /// Модель встречи между людьми
    /// </summary>
    public class Meeting
    {
        /// <summary>
        /// Уникальный идентификатор встречи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Первый участник встречи
        /// </summary>
        public MeetingPerson PersonA { get; set; }

        /// <summary>
        /// Второй участник встречи
        /// </summary>
        public MeetingPerson PersonB { get; set; }

        /// <summary>
        /// Детали встречи
        /// </summary>
        public MeetingDetails MeetingDetails { get; set; }

        /// <summary>
        /// Список свидетелей встречи
        /// </summary>
        public List<string> Witnesses { get; set; }
    }
}