namespace Detective.Models
{
    /// <summary>
    /// Ссылка на улику
    /// </summary>
    public class EvidenceRef
    {
        /// <summary>
        /// Идентификатор улики
        /// </summary>
        public int EvidenceId { get; set; }

        /// <summary>
        /// Описание улики
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// Правило логического вывода
    /// </summary>
    public class InferenceRule
    {
        /// <summary>
        /// Текст правила
        /// </summary>
        public string RuleText { get; set; }
    }

    /// <summary>
    /// Уровень уверенности
    /// </summary>
    public class ConfidenceLevel
    {
        /// <summary>
        /// Уровень уверенности (высокое, среднее, низкое)
        /// </summary>
        public string Level { get; set; }
    }

    /// <summary>
    /// Модель цепочки улик (логическая связь между уликами)
    /// </summary>
    public class Clue
    {
        /// <summary>
        /// Уникальный идентификатор цепочки
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Исходная улика
        /// </summary>
        public EvidenceRef FromEvidence { get; set; }

        /// <summary>
        /// Целевая улика
        /// </summary>
        public EvidenceRef ToEvidence { get; set; }

        /// <summary>
        /// Правило логического вывода
        /// </summary>
        public InferenceRule InferenceRule { get; set; }

        /// <summary>
        /// Уровень уверенности в связи
        /// </summary>
        public ConfidenceLevel Confidence { get; set; }
    }
}