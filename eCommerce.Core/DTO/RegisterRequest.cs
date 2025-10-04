namespace eCommerce.Core.DTO;
internal record RegisterRequest(
    string? Email,
    string? Password,
    string? PersonName,
    GenderOptions Gender);

