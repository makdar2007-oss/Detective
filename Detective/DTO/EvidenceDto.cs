using System;

namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных об улике
    /// </summary>
    public class EvidenceDto
    {
        /// <summary>
        /// Уникальный идентификатор улики
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Категория улики 
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Краткое описание улики
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Место обнаружения
        /// </summary>
        public string FoundAt { get; set; }

        /// <summary>
        /// Кто обнаружил улику
        /// </summary>
        public string FoundBy { get; set; }

        /// <summary>
        /// Имя подозреваемого, на которого указывает улика
        /// </summary>
        public string Suspect { get; set; }
    }
}