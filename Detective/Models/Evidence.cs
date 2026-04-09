using System;
using System.Collections.Generic;

namespace Detective.Models
{
    /// <summary>
    /// Тип улики
    /// </summary>
    public class EvidenceType
    {
        /// <summary>
        /// Категория улики (физическая, цифровая, документальная)
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Подтип улики
        /// </summary>
        public string Subtype { get; set; }
    }

    /// <summary>
    /// Описание улики
    /// </summary>
    public class EvidenceDescription
    {
        /// <summary>
        /// Краткое описание улики
        /// </summary>
        public string Short { get; set; }

        /// <summary>
        /// Полное описание улики
        /// </summary>
        public string Full { get; set; }
    }

    /// <summary>
    /// Информация об обнаружении улики
    /// </summary>
    public class FoundInfo
    {
        /// <summary>
        /// Место обнаружения улики
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Кто обнаружил улику
        /// </summary>
        public string FoundBy { get; set; }

        /// <summary>
        /// Дата обнаружения
        /// </summary>
        public string DateFound { get; set; }
    }

    /// <summary>
    /// Запись о передаче улики (цепочка хранения)
    /// </summary>
    public class CustodyEntry
    {
        /// <summary>
        /// Дата передачи
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// Лицо, принявшее улику
        /// </summary>
        public string person { get; set; }

        /// <summary>
        /// Действие, произведённое с уликой
        /// </summary>
        public string action { get; set; }
    }

    /// <summary>
    /// Информация о том, на кого указывает улика
    /// </summary>
    public class PointsTo
    {
        /// <summary>
        /// Идентификатор подозреваемого
        /// </summary>
        public Guid PersonId { get; set; }

        /// <summary>
        /// Имя подозреваемого
        /// </summary>
        public string PersonName { get; set; }

        /// <summary>
        /// Уровень уверенности (от 0 до 1)
        /// </summary>
        public double Confidence { get; set; }
    }

    /// <summary>
    /// Модель улики
    /// </summary>
    public class Evidence
    {
        /// <summary>
        /// Уникальный идентификатор улики
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// Уникальный идентификатор улики короткий
        /// </summary>
        public int NumberId { get; set; }
        /// <summary>
        /// Идентификатор дела, к которому относится улика
        /// </summary>
        public Guid CaseId { get; set; }

        /// <summary>
        /// Тип улики
        /// </summary>
        public EvidenceType EvidenceType { get; set; }

        /// <summary>
        /// Описание улики
        /// </summary>
        public EvidenceDescription Description { get; set; }

        /// <summary>
        /// Информация об обнаружении
        /// </summary>
        public FoundInfo FoundInfo { get; set; }

        /// <summary>
        /// Цепочка хранения улики
        /// </summary>
        public List<CustodyEntry> ChainOfCustody { get; set; }

        /// <summary>
        /// На кого указывает улика
        /// </summary>
        public PointsTo PointsTo { get; set; }
    }
}