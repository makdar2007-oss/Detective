using System.Collections.Generic;

namespace Detective.Models
{
    /// <summary>
    /// Корневой объект данных детективного агентства
    /// Содержит все данные: людей, дела, улики, версии и т.д.
    /// </summary>
    public class DetectiveData
    {
        /// <summary>
        /// Список всех людей (детективы, подозреваемые, свидетели, потерпевшие)
        /// </summary>
        public List<Person> Persons { get; set; }

        /// <summary>
        /// Список всех дел
        /// </summary>
        public List<Case> Cases { get; set; }

        /// <summary>
        /// Список всех версий расследования
        /// </summary>
        public List<Hypothesis> Hypotheses { get; set; }

        /// <summary>
        /// Список всех мотивов преступлений
        /// </summary>
        public List<Motive> Motives { get; set; }

        /// <summary>
        /// Список всех следственных действий
        /// </summary>
        public List<InvestigativeAction> InvestigativeActions { get; set; }

        /// <summary>
        /// Список записей о местонахождении людей во времени
        /// </summary>
        public List<LocationTime> LocationTimes { get; set; }

        /// <summary>
        /// Список всех встреч между людьми
        /// </summary>
        public List<Meeting> Meetings { get; set; }

        /// <summary>
        /// Список всех улик
        /// </summary>
        public List<Evidence> Evidences { get; set; }

        /// <summary>
        /// Список логических связей между уликами
        /// </summary>
        public List<Clue> Clues { get; set; }
    }
}