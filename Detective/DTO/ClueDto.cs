using System;

namespace Detective.DTO
{
    /// <summary>
    /// DTO для передачи данных о цепочке улик
    /// </summary>
    public class ClueDto
    {
        /// <summary>
        /// Уникальный идентификатор цепочки
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Описание исходной улики
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Описание целевой улики
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Правило логического вывода
        /// </summary>
        public string Rule { get; set; }

        /// <summary>
        /// Уровень уверенности в связи
        /// </summary>
        public string Confidence { get; set; }
    }
}