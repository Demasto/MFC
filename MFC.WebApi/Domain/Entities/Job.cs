namespace Domain.Entities;

public class Job
{
    public long Id { get; set; }
    public string UserId { get; set; } = null!;
    public string ServiceName { get; set; } = null!;
    public ProcessState State { get; set; } = ProcessState.Created;
}
/// <summary>
/// Заявления для студентов ? радотников
/// Скачивать пустые заявления (авто заполненные)
/// Заявления для работников и отдельно для студентов
/// ДОбавить поле (Форма обучения) очно, заочно
///
/// Список справок (с генерацией) - автоматически заполняется и оптравляется
/// Добавить роль (рабочих в унике)
/// новые поля - Должнолсть - институт
/// </summary>
public enum ProcessState
{
    Created,
    InProcess,
    Ready,
    Cancelled,
    Received
}