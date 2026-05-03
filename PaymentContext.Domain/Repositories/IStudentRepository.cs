using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Repositories;

public interface IStudentRepository
{
    // ─── Leituras ───────────────────────
    Task<Student?> GetByIdAsync(
        Guid id,
        CancellationToken ct = default);

    Task<Student?> GetByEmailAsync(
        Email email,
        CancellationToken ct = default);

    Task<Student?> GetByDocumentAsync(
        Document document,
        CancellationToken ct = default);

    Task<bool> EmailExistsAsync(
        Email email,
        CancellationToken ct = default);

    Task<bool> DocumentExistsAsync(
        Document document,
        CancellationToken ct = default);

    // ─── Escritas ───────────────────────
    Task AddAsync(
        Student student,
        CancellationToken ct = default);

    Task SaveChangesAsync(
        CancellationToken ct = default);
}
