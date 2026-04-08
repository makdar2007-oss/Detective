using System;
using System.Text;
using System.Windows.Forms;
using Detective.Models;

namespace Detective.Forms
{
    /// <summary>
    /// Форма для отображения детальной информации о выбранной сущности
    /// </summary>
    public partial class Details : Form
    {
        /// <summary>
        /// Конструктор формы деталей
        /// </summary>
        public Details(DetectiveData data, string entityType, int id)
        {
            InitializeComponent();
            LoadDetails(data, entityType, id);
        }
        /// <summary>
        /// Загружает и отображает детальную информацию о записи
        /// </summary>
        private void LoadDetails(DetectiveData data, string entityType, int id)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"  {GetRussianName(entityType)}");

            if (entityType == "Persons")
            {
                var p = data.Persons?.Find(x => x.Id == id);
                if (p != null)
                {
                    sb.AppendLine($"ID: {p.Id}");
                    sb.AppendLine($"ФИО: {p.FullName}");
                    sb.AppendLine($"Роль: {p.Role}");
                    sb.AppendLine();
                    sb.AppendLine("КОНТАКТЫ");
                    sb.AppendLine($"Телефон: {p.Contact?.Phone ?? "—"}");
                    sb.AppendLine($"Email: {p.Contact?.Email ?? "—"}");
                    sb.AppendLine($"Адрес: {p.Contact?.Address ?? "—"}");
                    sb.AppendLine();
                    sb.AppendLine("БИОМЕТРИЯ");
                    sb.AppendLine($"Фото: {p.Biometrics?.Photo ?? "—"}");
                    sb.AppendLine($"Хэш: {p.Biometrics?.FingerprintHash ?? "—"}");
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else if (entityType == "Cases")
            {
                var c = data.Cases?.Find(x => x.Id == id);
                if (c != null)
                {
                    sb.AppendLine($"ID: {c.Id}");
                    sb.AppendLine($"Название: {c.Title}");
                    sb.AppendLine($"Статус: {c.Status?.CurrentStatus ?? "—"}");
                    sb.AppendLine();
                    sb.AppendLine("ДЕТАЛИ ПРЕСТУПЛЕНИЯ");
                    sb.AppendLine($"Тип: {c.CrimeDetails?.CrimeType ?? "—"}");
                    sb.AppendLine($"Дата открытия: {c.CrimeDetails?.DateOpened ?? "—"}");
                    sb.AppendLine($"Место: {c.CrimeDetails?.CrimeLocation ?? "—"}");
                    sb.AppendLine($"Детектив: {c.CrimeDetails?.LeadDetective ?? "—"}");
                    sb.AppendLine();
                    sb.AppendLine("ХРОНОЛОГИЯ");
                    sb.AppendLine($"Начало: {c.Timeline?.Start ?? "—"}");
                    if (c.Timeline?.KeyMoments != null && c.Timeline.KeyMoments.Count > 0)
                    {
                        sb.AppendLine("Ключевые моменты:");
                        foreach (var m in c.Timeline.KeyMoments)
                            sb.AppendLine($"  • {m.time} — {m.description}");
                    }
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else if (entityType == "Evidences")
            {
                var e = data.Evidences?.Find(x => x.Id == id);
                if (e != null)
                {
                    sb.AppendLine($"ID: {e.Id}");
                    sb.AppendLine($"Категория: {e.EvidenceType?.Category ?? "—"}");
                    sb.AppendLine($"Подтип: {e.EvidenceType?.Subtype ?? "—"}");
                    sb.AppendLine();
                    sb.AppendLine("ОПИСАНИЕ");
                    sb.AppendLine($"Кратко: {e.Description?.Short ?? "—"}");
                    sb.AppendLine($"Полностью: {e.Description?.Full ?? "—"}");
                    sb.AppendLine();
                    sb.AppendLine("ОБНАРУЖЕНИЕ");
                    sb.AppendLine($"Место: {e.FoundInfo?.Location ?? "—"}");
                    sb.AppendLine($"Кто нашёл: {e.FoundInfo?.FoundBy ?? "—"}");
                    sb.AppendLine($"Дата: {e.FoundInfo?.DateFound ?? "—"}");
                    sb.AppendLine();
                    sb.AppendLine("УКАЗЫВАЕТ НА");
                    sb.AppendLine($"Подозреваемый: {e.PointsTo?.PersonName ?? "—"}");
                    if (e.PointsTo != null)
                        sb.AppendLine($"Уверенность: {e.PointsTo.Confidence * 100}%");
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else if (entityType == "Hypotheses")
            {
                var h = data.Hypotheses?.Find(x => x.Id == id);
                if (h != null)
                {
                    sb.AppendLine($"ID: {h.Id}");
                    sb.AppendLine($"Описание: {h.Description ?? "—"}");
                    sb.AppendLine($"Приоритет: {h.Priority?.Level ?? "—"}");
                    sb.AppendLine($"Создатель: {h.Creator?.Name ?? "—"} ({h.Creator?.Role ?? "—"})");
                    sb.AppendLine($"Подтверждена: {(h.Confirmation?.IsConfirmed == true ? "Да" : "Нет")}");
                    sb.AppendLine($"Обновлено: {h.Confirmation?.LastUpdate ?? "—"}");
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else if (entityType == "Motives")
            {
                var m = data.Motives?.Find(x => x.Id == id);
                if (m != null)
                {
                    sb.AppendLine($"ID: {m.Id}");
                    sb.AppendLine($"Подозреваемый: {m.Person?.Name ?? "—"}");
                    sb.AppendLine($"Тип мотива: {m.MotiveDetails?.Type ?? "—"}");
                    sb.AppendLine($"Сила: {m.MotiveDetails?.Strength}/10");
                    sb.AppendLine($"Описание: {m.MotiveDetails?.Description ?? "—"}");
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else if (entityType == "InvestigativeActions")
            {
                var a = data.InvestigativeActions?.Find(x => x.Id == id);
                if (a != null)
                {
                    sb.AppendLine($"ID: {a.Id}");
                    sb.AppendLine($"Тип: {a.ActionType?.Name ?? "—"}");
                    sb.AppendLine($"Код: {a.ActionType?.Code ?? "—"}");
                    sb.AppendLine($"Цель: {a.Target?.PersonName ?? "—"}");
                    sb.AppendLine($"Результат: {a.Result?.Summary ?? "—"}");
                    sb.AppendLine($"Дата: {a.Result?.Date ?? "—"}");
                    if (a.NewEvidences != null && a.NewEvidences.Count > 0)
                        sb.AppendLine($"Новые улики: {string.Join(", ", a.NewEvidences)}");
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else if (entityType == "LocationTimes")
            {
                var l = data.LocationTimes?.Find(x => x.Id == id);
                if (l != null)
                {
                    sb.AppendLine($"ID: {l.Id}");
                    sb.AppendLine($"Человек: {l.Person?.Name ?? "—"}");
                    sb.AppendLine($"Место: {l.Location?.Name ?? "—"}");
                    sb.AppendLine($"Тип места: {l.Location?.Type ?? "—"}");
                    sb.AppendLine($"Вход: {l.TimeInterval?.Enter ?? "—"}");
                    sb.AppendLine($"Выход: {l.TimeInterval?.Exit ?? "—"}");
                    sb.AppendLine($"Длительность: {l.TimeInterval?.Duration ?? "—"}");
                    sb.AppendLine($"Источник: {l.Source?.Type ?? "—"}");
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else if (entityType == "Meetings")
            {
                var m = data.Meetings?.Find(x => x.Id == id);
                if (m != null)
                {
                    sb.AppendLine($"ID: {m.Id}");
                    sb.AppendLine($"Участник A: {m.PersonA?.Name ?? "—"}");
                    sb.AppendLine($"Участник B: {m.PersonB?.Name ?? "—"}");
                    sb.AppendLine($"Время: {m.MeetingDetails?.Time ?? "—"}");
                    sb.AppendLine($"Место: {m.MeetingDetails?.Location ?? "—"}");
                    sb.AppendLine($"Тайная: {(m.MeetingDetails?.IsSecret == true ? "Да" : "Нет")}");
                    if (m.Witnesses != null && m.Witnesses.Count > 0)
                        sb.AppendLine($"Свидетели: {string.Join(", ", m.Witnesses)}");
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else if (entityType == "Clues")
            {
                var c = data.Clues?.Find(x => x.Id == id);
                if (c != null)
                {
                    sb.AppendLine($"ID: {c.Id}");
                    sb.AppendLine($"От улики: {c.FromEvidence?.Description ?? "—"} (ID: {c.FromEvidence?.EvidenceId})");
                    sb.AppendLine($"К улике: {c.ToEvidence?.Description ?? "—"} (ID: {c.ToEvidence?.EvidenceId})");
                    sb.AppendLine($"Правило: {c.InferenceRule?.RuleText ?? "—"}");
                    sb.AppendLine($"Уверенность: {c.Confidence?.Level ?? "—"}");
                }
                else sb.AppendLine("Данные не найдены!");
            }
            else
            {
                sb.AppendLine($"Информация для {entityType} не добавлена.");
            }

            sb.AppendLine();
            txtDetails.Text = sb.ToString();
        }
        /// <summary>
        /// Возвращает русское название 
        /// </summary>
        private string GetRussianName(string entityType)
        {
            if (entityType == "Persons") return "ЛИЧНЫЕ ДАННЫЕ";
            if (entityType == "Cases") return "ДЕЛО";
            if (entityType == "Hypotheses") return "ВЕРСИЯ";
            if (entityType == "Motives") return "МОТИВ";
            if (entityType == "InvestigativeActions") return "СЛЕДСТВЕННОЕ ДЕЙСТВИЕ";
            if (entityType == "LocationTimes") return "ЛОКАЦИЯ";
            if (entityType == "Meetings") return "ВСТРЕЧА";
            if (entityType == "Evidences") return "УЛИКА";
            if (entityType == "Clues") return "ЦЕПОЧКА УЛИК";
            return entityType.ToUpper();
        }
    }
}