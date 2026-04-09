using System;

namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных о версии
    /// </summary>
    public class HypothesisDto
    {
        /// <summary>
        /// Уникальный идентификатор версии
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Описание версии
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Приоритет версии (основная, запасная)
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Имя создателя версии
        /// </summary>
        public string CreatorName { get; set; }

        /// <summary>
        /// Статус подтверждения версии
        /// </summary>
        public bool IsConfirmed { get; set; }
    }
}