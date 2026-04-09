using System;

namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных о следственном действии
    /// </summary>
    public class InvestigativeActionDto
    {
        /// <summary>
        /// Уникальный идентификатор действия
        /// </summary>
        public Guid
            Id { get; set; }

        /// <summary>
        /// Тип следственного действия
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Цель следственного действия
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Краткий результат действия
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Дата проведения
        /// </summary>
        public string Date { get; set; }
    }
}